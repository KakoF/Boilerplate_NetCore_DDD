using System;
using System.Threading.Tasks;
using Api.Data.Context.Interfaces;
using Api.Domain.Dtos;
using Api.Domain.Dtos.Register;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Interfaces.Utils;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IUserRepository _repository;

        private readonly IHash _hash;
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public RegisterService(IUserRepository repository, IMapper mapper, IUnitOfWork uof, IHash hash)
        {
            _hash = hash;
            _uof = uof;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<object> Register(RegisterRequestDto user)
        {
            if (user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                try
                {
                    if (_repository.GetUserByEmail(user.Email) != null)
                    {
                        throw new Exception("E-mail já cadastrado");
                    }
                    //_uof.Begin();
                    user.Password = _hash.Cryptography(user.Password);
                    var model = _mapper.Map<UserModel>(user);
                    var entity = _mapper.Map<UserEntity>(model);
                    var result = await _repository.InsertAsync(entity);
                    if (result == null)
                    {
                        return new
                        {
                            authenticated = false,
                            message = "Falha ao registar"
                        };
                    }
                    _uof.Commmit();
                    return _mapper.Map<RegisterResponseDto>(result);
                }
                catch (System.Exception e)
                {
                    //_uof.Rollback();
                    throw e;
                }
            }

            throw new Exception("Dados inválidos");
        }
    }
}