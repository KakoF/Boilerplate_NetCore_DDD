using System;
using System.Net;
using System.Threading.Tasks;
using Api.Application.Helpers;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;
        public LoginController(ILoginService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto user)
        {
            try
            {
                var result = await _service.Login(user);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ApiErrorResponse((int)HttpStatusCode.BadRequest, e.Message));
            }
        }
    }
}