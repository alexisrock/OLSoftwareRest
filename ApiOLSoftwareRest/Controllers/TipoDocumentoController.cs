using ApiOLSoftwareRest.Helpers;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiOLSoftwareRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoDocumentoController : ControllerBase
    {

        public readonly ITipoDocumentoService tipoDocumentoService;

        public TipoDocumentoController(ITipoDocumentoService tipoDocumentoService)
        {
            this.tipoDocumentoService = tipoDocumentoService;
        }

        [HttpGet, Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var candidatos = await tipoDocumentoService.GetAll();
                return Ok(candidatos);
            }
            catch (Exception)
            {
                return Problem();
            }
        }

    }
}
