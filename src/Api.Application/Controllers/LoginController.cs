using System;
using System.Net;
using System.Threading.Tasks;
using Api.Application.Helpers;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;
        private readonly ILogger<LoginController> _logger;
        public LoginController(ILoginService service, ILogger<LoginController> logger)
        {
            _logger = logger;
            _service = service;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto user)
        {
            try
            {
                _logger.LogInformation("Hello from the Login() method!");
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