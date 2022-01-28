using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nubimetrics_Challenge.Services.BaseService.Interfaces;
using System;
using System.Threading.Tasks;

namespace Nubimetrics_Challenge.WebApi.Infraestructure
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class CrudControllerBase<TDto, TIService> : ControllerBase
        where TDto : class
        where TIService : ICrudBaseService<TDto>
    {
        private readonly TIService _service;

        public CrudControllerBase(TIService service)
        {
            _service = service;
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TDto>> Create([FromBody] TDto dto)
        {
            if (dto is null)
                return BadRequest();

            var result = await _service.Create(dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("Get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TDto>> Get(Guid id)
        {
            if (id == null || id == Guid.Empty)
                return BadRequest();

            var result = await _service.GetAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TDto>> GetAll()
        {
            var result = await _service.GetAsync();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TDto>> Update(Guid id, [FromBody] TDto dto)
        {
            if (id == null || id == Guid.Empty || dto is null)
                return BadRequest();

            var result = await _service.Update(id, dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TDto>> Delete(Guid id)
        {
            if (id == null || id == Guid.Empty)
                return BadRequest();

            await _service.Delete(id);

            return Ok();
        }
    }
}
