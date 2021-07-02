using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDto> Get(int id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDtoCreateResult> Post(UserDtoCreate item);
        Task<UserDtoUpdateResult> Put(int id, UserDtoUpdate item);
        Task<bool> Delete(int id);
    }
}