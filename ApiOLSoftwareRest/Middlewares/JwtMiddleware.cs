using Core.Interfaces;

namespace ApiOLSoftwareRest.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate requestDelegate;


        /// <summary>
        /// Constructor
        /// </summary>
        public JwtMiddleware(RequestDelegate requestDelegat)
        {
            this.requestDelegate = requestDelegat;

        }

        /// <summary>
        /// Metodo para validar el token
        /// </summary>

        public async Task InvokeAsync(HttpContext context, IUsuarioService tokenService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if ((token is not null) && ValidateToken(token, tokenService))
            {
                context.Items["UserId"] = "ALEXIS";
            }
            await requestDelegate(context);
        }

        private bool ValidateToken(string token, IUsuarioService tokenService)
        {
            return tokenService.ValidateToken(token).Result;
        }


    }
}
