using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context.Interfaces;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _repository;
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public UserService(IRepository<UserEntity> repository, IMapper mapper, IUnitOfWork uof)
        {
            _uof = uof;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                _uof.Begin();
                var result = await _repository.DeleteAsync(id);
                _uof.Commmit();
                return result;
            }
            catch (System.Exception e)
            {
                _uof.Rollback();
                throw e;
            }

        }

        public async Task<UserDto> Get(int id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UserDto>(entity) ?? new UserDto();
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var entityList = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UserDto>>(entityList);
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate item)
        {
            try
            {
                _uof.Begin();
                var model = _mapper.Map<UserModel>(item);
                var entity = _mapper.Map<UserEntity>(model);
                var result = await _repository.InsertAsync(entity);
                _uof.Commmit();
                return _mapper.Map<UserDtoCreateResult>(result);
            }
            catch (System.Exception e)
            {
                _uof.Rollback();
                throw e;
            }

        }

        public async Task<UserDtoUpdateResult> Put(int id, UserDtoUpdate item)
        {
            try
            {
                _uof.Begin();
                var model = _mapper.Map<UserModel>(item);
                var entity = _mapper.Map<UserEntity>(model);
                var Userpassword = await _repository.SelectAsync(id);
                entity.Password = Userpassword.Password;
                var result = await _repository.UpdasteAsync(id, entity);
                _uof.Commmit();
                return _mapper.Map<UserDtoUpdateResult>(result);
            }
            catch (System.Exception e)
            {
                _uof.Rollback();
                throw e;
            }

        }
    }
}