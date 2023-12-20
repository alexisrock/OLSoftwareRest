using ApiOLSoftwareRest.Helpers;
using Core.Interfaces;
using Core.Repository;
using Domain.Common;
using Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiOLSoftwareRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AspiranteController : ControllerBase
    {

        private readonly IAspiranteService _aspiranteService;

        public AspiranteController(IAspiranteService aspiranteService)
        {
            _aspiranteService = aspiranteService;
        }



        [HttpGet, Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listAspirante = await _aspiranteService.GetAll();
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
                var aspirante = await _aspiranteService.GetId(id);
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


        [HttpPost, Route("[action]")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] AspiranteRequest aspiranteRequest)
        {
            try
            {
                var aspirante = await _aspiranteService.Create(aspiranteRequest);
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


        [HttpPut, Route("[action]")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] AspiranteUpdateRequest aspiranteRequest)
        {
            try
            {
                var aspirante = await _aspiranteService.Update(aspiranteRequest);
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



        [HttpDelete, Route("[action]/{id}")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var aspirante = await _aspiranteService.Delete(id);
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

    }
}
