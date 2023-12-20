using ApiOLSoftwareRest.Helpers;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiOLSoftwareRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EstadoPruebaController : ControllerBase
    {

        private readonly IEstadoPruebaService estadoPruebaService;
        public EstadoPruebaController(IEstadoPruebaService estadoPruebaService)
        {
            this.estadoPruebaService = estadoPruebaService;
        }

        [HttpGet, Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var estadoPrueba = await estadoPruebaService.GetAll();
                return Ok(estadoPrueba);
            }
            catch (Exception)
            {
                return Problem();
            }
        }

    }
}
