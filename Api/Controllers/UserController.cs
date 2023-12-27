using BusinessLayer.ResponseModels;
using BussinesLayer.AuthLogic.Abstracts;
using CommonsLayer.DTO.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// API for managing events
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IEmployeeManagement management;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserController(IEmployeeManagement management)
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
        [HttpGet("GetUsers")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUsers()
        {
            var result = await management.GetAllUser();

            return result.Status is ResponseStatus.Successful or ResponseStatus.Warning
                ? Ok(result)
                : BadRequest(result);
        }

    }
}
