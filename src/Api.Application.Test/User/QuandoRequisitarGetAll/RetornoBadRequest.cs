using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.QuandoRequisitarGetAll
{
    public class RetornoBadRequest
    {
        private UsersController _controller;
        [Fact(DisplayName = "Não Foi Possivel Realizar O GetAll")]
        public async Task Erro_Ao_Invocar_A_Controller_GetAll()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<UserDto>
                {
                   new UserDto{
                    Id = 1,
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow
                   },
                   new UserDto{
                    Id = 2,
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow
                   },
                   new UserDto{
                    Id = 3,
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow
                   }
                }
            );

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");
            var result = await _controller.Delete(default(int));
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}