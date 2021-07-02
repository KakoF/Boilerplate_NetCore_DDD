using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.QuandoRequisitarGet
{
    public class RetornoBadRequest
    {
        private UsersController _controller;
        [Fact(DisplayName = "Não Foi Possivel Realizar O Get")]
        public async Task Erro_Ao_Invocar_A_Controller_Get()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Get(It.IsAny<int>())).ReturnsAsync(
                new UserDto
                {
                    Id = 1,
                    Email = email,
                    Name = nome,
                    CreateAt = DateTime.UtcNow
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