using BusinessLayer.ResponseModels;
using BussinesLayer.TaskLogics.Abstracts;
using CommonsLayer.DTO.TaskManagement;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    /// <summary>
    /// API for managing events
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagementController : ControllerBase
    {
        private readonly ITaskManagement management;

        /// <summary>
        /// Constructor
        /// </summary>
        public TaskManagementController(ITaskManagement management)
        {
            this.management = management;
        }


        /// <summary>
        /// Registra una nuevo producto.
        /// </summary>
        /// <param name="productmodel">Datos del producto que se va a registrar.</param>
        /// <returns>Respuesta que indica el resultado de la operación.</returns>
        /// <remarks>
        /// </remarks>
        [HttpPost("RegisterTask")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterTask(TaskCreateDto taskModel)
        {
            var result = await management.RegisterTask(taskModel);

            return result.Status is ResponseStatus.Successful or ResponseStatus.Warning
                ? Ok(result)
                : BadRequest(result);
        }
        ///// <summary>
        ///// Edita un producto.
        ///// </summary>
        ///// <param name="productmodel">Datos del producto que se va a Editar.</param>
        ///// <returns>Respuesta que indica el resultado de la operación.</returns>
        ///// <remarks>
        ///// </remarks>
        [HttpPut("UpdateTask")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateTask(TaskCreateDto taskModel)
        {
            var result = await management.UpdateTask(taskModel);

            return result.Status is ResponseStatus.Successful or ResponseStatus.Warning
                ? Ok(result)
                : BadRequest(result);
        }
        ///// <summary>
        ///// Obtiene un producto.
        ///// </summary>
        ///// <param name="productId">Id del producto a obtener.</param>
        ///// <returns>Respuesta que indica el resultado de la operación.</returns>
        ///// <remarks>
        ///// </remarks>
        [HttpGet("GetTasks")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTasks(Guid taskId)
        {
            var result = await management.GetTasks(taskId);

            return result.Status is ResponseStatus.Successful or ResponseStatus.Warning
                ? Ok(result)
                : BadRequest(result);
        }
        ///// <summary>
        ///// Elimina un producto.
        ///// </summary>
        ///// <param name="productId">Id del producto a Eliminar.</param>
        ///// <returns>Respuesta que indica el resultado de la operación.</returns>
        ///// <remarks>
        ///// </remarks>
        [HttpDelete("DeleteTask")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteTask(Guid taskId)
        {
            var result = await management.DeleteTask(taskId);

            return result.Status is ResponseStatus.Successful or ResponseStatus.Warning
                ? Ok(result)
                : BadRequest(result);
        }
        ///// <summary>
        ///// Obtiene un producto.
        ///// </summary>
        ///// <returns>Obtiene todas las recetas del sistema.</returns>
        ///// <remarks>
        ///// </remarks>
        [HttpGet("GetAllTask")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllTask()
        {
            var result = await management.GetAllTask();

            return result.Status is ResponseStatus.Successful or ResponseStatus.Warning
                ? Ok(result)
                : BadRequest(result);
        }
    }
}
