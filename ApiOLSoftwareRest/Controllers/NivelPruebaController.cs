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
    public class NivelPruebaController : ControllerBase
    {

        public readonly INivelPruebaService nivelPruebaService;

        public NivelPruebaController(INivelPruebaService nivelPruebaService)
        {
            this.nivelPruebaService = nivelPruebaService;
        }


        [HttpGet, Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var nivelPrueba = await nivelPruebaService.GetAll();
                return Ok(nivelPrueba);
            }
            catch (Exception)
            {
                return Problem();
            }
        }

    }
}
