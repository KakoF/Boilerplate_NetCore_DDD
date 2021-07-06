using System;
using System.Net;
using System.Threading.Tasks;
using Api.Application.Helpers;
using Api.Domain.Dtos.Register;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _service;
        public RegisterController(IRegisterService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Register([FromBody] RegisterRequestDto user)
        {
            try
            {
                var result = await _service.Register(user);
                return Ok(new { message = "Registrado com sucesso", data = result });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ApiErrorResponse((int)HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}