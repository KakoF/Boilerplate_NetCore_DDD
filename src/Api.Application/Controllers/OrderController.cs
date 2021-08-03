

using System;
using System.Net;
using System.Threading.Tasks;
using Api.Application.Helpers;
using Api.Application.Helpers.Interfaces;
using Api.Domain.Dtos.Order;
using Api.Domain.Interfaces.Services.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
  //[Authorize("Bearer", Roles = "Admin")]
  [Route("api/[controller]")]
  [ApiController]
  public class OrderController : ControllerBase
  {
    private readonly IOrderService _service;
    private readonly IUserProvider _provider;
    public OrderController(IOrderService service, IUserProvider provider)
    {
      _service = service;
      _provider = provider;
    }
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] OrderDtoCreate order)
    {
      try
      {
        var result = await _service.Post(order);
        if (result != null)
          return Ok(new { message = "Pedido salvo com sucesso", data = result });
        //return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result);
        return BadRequest();
      }
      catch (Exception e)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, new ApiErrorResponse((int)HttpStatusCode.InternalServerError, e.Message));
      }
    }
  }
}