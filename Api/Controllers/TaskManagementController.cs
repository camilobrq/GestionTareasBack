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
        /// Registra una nueva tarea.
        /// </summary>
        /// <param name="productmodel">Datos de la tarea que se va a registrar.</param>
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
        ///// Edita una tarea.
        ///// </summary>
        ///// <param name="taskModel">Datos de la tarea que se va a Editar.</param>
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
        ///// Elimina una tarea.
        ///// </summary>
        ///// <param name="taskId">Id de la tarea a Eliminar.</param>
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
        ///// Obtiene todas las tareas .
        ///// </summary>
        ///// <returns>Obtiene todas las tareas del sistema.</returns>
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
        ///// <summary>
        ///// Obtiene un las tareas por usuario.
        ///// </summary>
        ///// <returns>Obtiene un las tareas por usuario..</returns>
        ///// <remarks>
        ///// </remarks>
        [HttpGet("GetTasksForUser")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTasksForUser(Guid userId)
        {
            var result = await management.GetTasksForUser(userId);

            return result.Status is ResponseStatus.Successful or ResponseStatus.Warning
                ? Ok(result)
                : BadRequest(result);
        }
    }
}
