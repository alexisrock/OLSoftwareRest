using ApiOLSoftwareRest.Helpers;
using Core.Interfaces;
using Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiOLSoftwareRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoPruebaController : ControllerBase
    {

        private readonly ITipoPruebaService tipoPruebaService;

        public TipoPruebaController(ITipoPruebaService tipoPruebaService)
        {
            this.tipoPruebaService = tipoPruebaService;
        }


        [HttpGet, Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var tipoPrueba = await tipoPruebaService.GetAll();
                return Ok(tipoPrueba);
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}
