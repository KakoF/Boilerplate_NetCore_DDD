using System;
using System.Net;
using System.Threading.Tasks;
using Api.Application.Helpers;
using Api.Application.Helpers.Interfaces;
using Api.Domain.Dtos;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Application.Controllers
{
  //[Authorize("Bearer", Roles = "Admin")]
  [Authorize("Bearer")]
  [Route("api/[controller]")]
  [ApiController]
  public class MeController : ControllerBase
  {
    private readonly IUserService _service;
    private readonly IUserProvider _provider;
    public MeController(IUserService service, IUserProvider provider)
    {
      _service = service;
      _provider = provider;
    }
    [HttpGet]
    public async Task<ActionResult> Index()
    {
      try
      {
        var result = await _service.Get(_provider.User().Id);
        return Ok(result);
      }
      catch (Exception e)
      {

        return StatusCode((int)HttpStatusCode.BadRequest, new ApiErrorResponse((int)HttpStatusCode.BadRequest, e.Message));
      }
    }
  }
}