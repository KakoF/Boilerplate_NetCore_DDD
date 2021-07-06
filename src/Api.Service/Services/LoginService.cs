using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Interfaces.Utils;
using Api.Domain.Repository;
using Api.Domain.Security;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly SigninConfigurations _signinConfigurations;
        private readonly IHash _hash;

        private IConfiguration _configuration { get; }
        public LoginService(IUserRepository repository, IMapper mapper, SigninConfigurations signinConfigurations, IConfiguration configuration, IHash hash)
        {
            _hash = hash;
            _repository = repository;
            _signinConfigurations = signinConfigurations;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<object> Login(LoginDto user)
        {
            var baseUser = new UserEntity();
            if (user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                user.Password = _hash.Cryptography(user.Password);
                baseUser = await _repository.Login(user.Email, user.Password);
                if (baseUser == null)
                {
                    throw new Exception("Usuário não encontrado");
                }

                var userLogin = _mapper.Map<LoginResponseDto>(baseUser);

                var identity = new ClaimsIdentity(
                    new GenericIdentity(userLogin.Id.ToString()),
                    new[]{
                        //new Claim(JwtRegisteredClaimNames.Sid, userLogin.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Name, userLogin.Name),
                        new Claim(JwtRegisteredClaimNames.UniqueName, userLogin.Email),
                        new Claim(ClaimTypes.Role, userLogin.Role),
                    }
                );
                DateTime createdDate = DateTime.Now;
                DateTime expirationDate = createdDate + TimeSpan.FromSeconds(Convert.ToInt32(Environment.GetEnvironmentVariable("Seconds")));

                var handler = new JwtSecurityTokenHandler();
                var token = CreateToken(identity, createdDate, expirationDate, handler);
                return SuccessObject(createdDate, expirationDate, token, userLogin);


            }

            return null;
        }


        private string CreateToken(ClaimsIdentity identity, DateTime createdDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = Environment.GetEnvironmentVariable("Issuer"),
                Audience = Environment.GetEnvironmentVariable("Audience"),
                SigningCredentials = _signinConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createdDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }
        private object SuccessObject(DateTime createdDate, DateTime expirationDate, string token, LoginResponseDto user)
        {
            return new
            {
                authenticated = true,
                created = createdDate,
                expiration = expirationDate,
                accessToken = token,
                userName = user.Name,
                role = user.Role,
                message = "Usuário logado com sucesso.",
            };
        }
    }
}