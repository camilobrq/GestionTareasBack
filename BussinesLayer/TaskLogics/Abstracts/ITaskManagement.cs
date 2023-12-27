using BusinessLayer.ResponseModels;
using CommonsLayer.DTO.TaskManagement;
using EntityLayer.TaskModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.TaskLogics.Abstracts
{
    public interface ITaskManagement
    {
        Task<Response> RegisterTask(TaskCreateDto task);
        Task<Response> UpdateTask(TaskCreateDto task);
        Task<Response<List<TaskManager>>> GetTasksForUser(Guid userId);
        Task<Response> DeleteTask(Guid taskId);
        Task<Response<List<TaskManager>>> GetAllTask();
    }
}
