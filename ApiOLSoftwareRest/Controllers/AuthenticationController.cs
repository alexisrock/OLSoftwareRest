using Core.Interfaces;
using Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiOLSoftwareRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUsuarioService userService;

        /// <summary>
        /// Constructor
        /// </summary>
        public AuthenticationController(IUsuarioService userService)
        {
            this.userService = userService;
        }


        [HttpPost, Route("[action]")]
        [ProducesResponseType(typeof(UserTokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Authentication([FromBody] UserTokenRequest userTokenRequest)
        {
            try
            {
                var user = await userService.GetAuthentication(userTokenRequest);
                if (user is not null)
                    return Ok(user);
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
