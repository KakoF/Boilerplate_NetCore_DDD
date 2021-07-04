using System;
using System.Net;
using System.Threading.Tasks;
using Api.Application.Helpers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var data = await _service.GetAll();
                return Ok(new { message = "Registros encontrados", data = data });
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var data = await _service.Get(id);
                return Ok(new { message = "Registro encontrado", data = data });
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDtoCreate user)
        {
            try
            {
                var result = await _service.Post(user);
                if (result != null)
                    return Ok(new { message = "Registro salvo com sucesso", data = result });
                //return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result);
                return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserDtoUpdate user)
        {
            try
            {
                var result = await _service.Put(id, user);
                if (result != null)
                    //return Created(new Uri(Url.Link("GetWithId"), new { id = result.Id })), result);
                    return Ok(new { message = "Registro alterado com sucesso", data = result });

                return BadRequest();
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _service.Delete(id);
                return Ok(new { message = "Registro deletado com sucesso", data = result });
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}