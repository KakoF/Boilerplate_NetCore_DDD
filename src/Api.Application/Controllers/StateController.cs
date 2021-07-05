using System;
using System.Net;
using System.Threading.Tasks;
using Api.Application.Helpers;
using Api.Domain.Interfaces.Services.State;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _service;
        public StateController(IStateService service)
        {
            _service = service;
        }

        public async Task<ActionResult> GetAll()
        {
            try
            {
                var data = await _service.GetAll();
                return Ok(new { message = "Registros encontrados", data = data });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ApiErrorResponse((int)HttpStatusCode.InternalServerError, e.Message));
            }
        }

        public async Task<ActionResult> GetAllWithCity()
        {
            try
            {
                var data = await _service.GetAllWithCity();
                return Ok(new { message = "Registros encontrados", data = data });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ApiErrorResponse((int)HttpStatusCode.InternalServerError, e.Message));
            }
        }


    }
}