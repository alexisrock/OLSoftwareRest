using ApiOLSoftwareRest.Helpers;
using Core.Interfaces;
using Core.Repository;
using Domain.Common;
using Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiOLSoftwareRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PruebaSeleccionController : ControllerBase
    {



        private readonly IPruebaSeleccionService _pruebaSeleccionService;

        public PruebaSeleccionController(IPruebaSeleccionService pruebaSeleccionService)
        {
            _pruebaSeleccionService = pruebaSeleccionService;
        }

        [HttpGet, Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listAspirante = await _pruebaSeleccionService.GetAll();
                return Ok(listAspirante);
            }
            catch (Exception)
            {
                return Problem();
            }
        }


        [HttpGet, Route("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                var aspirante = await _pruebaSeleccionService.GetId(id);
                if (aspirante is not null)
                    return Ok(aspirante);
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return Problem();
            }
        }


        [HttpGet, Route("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPreguntasByIdPruebaSeleccion(int id)
        {
            try
            {
                var listPreguntas = await _pruebaSeleccionService.GetIdPreguntas(id);
                return Ok(listPreguntas);
            }
            catch (Exception)
            {
                return Problem();
            }
        }


        [HttpPost, Route("[action]")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] PruebaSeleccionRequest pruebaSeleccionRequest)
        {
            try
            {
                var result = await _pruebaSeleccionService.Create(pruebaSeleccionRequest);
                if (result is not null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return Problem();
            }
        }



        [HttpPut, Route("[action]")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] PruebaSeleccionUpdateRequest pruebaSeleccionUpdateRequest)
        {
            try
            {
                var result = await _pruebaSeleccionService.Update(pruebaSeleccionUpdateRequest);
                if (result is not null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return Problem();
            }
        }


        [HttpDelete, Route("[action]/{id}")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _pruebaSeleccionService.Delete(id);
                if (result is not null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}
