using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UserMapper : BaseTestService
    {
        [Fact(DisplayName = "É possivel Mapear os Modelos")]
        public void E_Possivel_Mapear_Os_Modelos()
        {
            var model = new UserModel
            {
                Id = 1,
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listaEntity = new List<UserEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new UserEntity
                {
                    Id = 1,
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listaEntity.Add(item);
            }

            // Model => Entidade
            var entity = Mapper.Map<UserEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.Email, model.Email);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            // Entity => Dto
            var userDto = Mapper.Map<UserDto>(entity);
            Assert.Equal(userDto.Id, entity.Id);
            Assert.Equal(userDto.Name, entity.Name);
            Assert.Equal(userDto.Email, entity.Email);

            // lista Entity => lista Dto
            var listaDto = Mapper.Map<List<UserDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Name, listaEntity[i].Name);
                Assert.Equal(listaDto[i].Email, listaEntity[i].Email);
            }

            // dto => create result
            var userDtoCreateResult = Mapper.Map<UserDtoCreateResult>(entity);
            Assert.Equal(userDtoCreateResult.Id, entity.Id);
            Assert.Equal(userDtoCreateResult.Name, entity.Name);
            Assert.Equal(userDtoCreateResult.Email, entity.Email);
            Assert.Equal(userDtoCreateResult.CreateAt, entity.CreateAt);


            // dto => update result
            var userDtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(entity);
            Assert.Equal(userDtoUpdateResult.Id, entity.Id);
            Assert.Equal(userDtoUpdateResult.Name, entity.Name);
            Assert.Equal(userDtoUpdateResult.Email, entity.Email);
            Assert.Equal(userDtoUpdateResult.UpdateAt, entity.UpdateAt);

            // dto => model
            var userModel = Mapper.Map<UserModel>(userDto);
            Assert.Equal(userModel.Id, userDto.Id);
            Assert.Equal(userModel.Name, userDto.Name);
            Assert.Equal(userModel.Email, userDto.Email);

            // dto => model
            var userDtoCreate = Mapper.Map<UserDtoCreate>(userModel);
            Assert.Equal(userDtoCreate.Name, userModel.Name);
            Assert.Equal(userDtoCreate.Email, userModel.Email);

            // dto => model
            var userDtoUpdate = Mapper.Map<UserDtoUpdate>(userModel);
            Assert.Equal(userDtoUpdate.Name, userModel.Name);
            Assert.Equal(userDtoUpdate.Email, userModel.Email);
        }

    }
}