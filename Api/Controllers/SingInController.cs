using BusinessLayer.ResponseModels;
using BussinesLayer.AuthLogic.Abstracts;
using BussinesLayer.TaskLogics.Abstracts;
using CommonsLayer.DTO.Auth;
using CommonsLayer.DTO.TaskManagement;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// API for managing events
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SingInController :ControllerBase
    {
        private readonly ISingInManagement management;

        /// <summary>
        /// Constructor
        /// </summary>
        public SingInController(ISingInManagement management)
        {
            this.management = management;
        }


        /// <summary>
        /// Inicio de sesion.
        /// </summary>
        /// <param name="UserCredentials">Datos para iniciar Sesion.</param>
        /// <returns>Respuesta que indica el resultado de la operación.</returns>
        /// <remarks>
        /// </remarks>
        [HttpPost("SingIn")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SingIn(UserCredentials user)
        {
            var result = await management.SingIn(user);

            return result.Status is ResponseStatus.Successful or ResponseStatus.Warning
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// Registro de usuario.
        /// </summary>
        /// <param name="UserCredentials">Datos para registro de usuario.</param>
        /// <returns>Respuesta que indica el resultado de la operación.</returns>
        /// <remarks>
        /// </remarks>
        [HttpPost("RegisterUser")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterUser(UserRegister user)
        {
            var result = await management.RegisterUser(user);

            return result.Status is ResponseStatus.Successful or ResponseStatus.Warning
                ? Ok(result)
                : BadRequest(result);
        }
    }
}
