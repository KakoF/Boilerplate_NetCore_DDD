using System;
using System.Net;
using System.Threading.Tasks;
using Api.Application.Helpers;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
        _logger.LogWarning("Tentativa de Login {User}", JsonConvert.SerializeObject(user));
        var result = await _service.Login(user);
        _logger.LogWarning("Usuario Autenticado {User}", JsonConvert.SerializeObject(result));
        return Ok(result);
      }
      catch (Exception e)
      {
        _logger.LogWarning("Falha na aunteticação {User}", e.Message);
        return StatusCode((int)HttpStatusCode.BadRequest, new ApiErrorResponse((int)HttpStatusCode.BadRequest, e.Message));
      }
    }
  }
}