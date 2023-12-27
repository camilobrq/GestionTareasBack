using EntityLayer.TaskModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Abstracts
{
    public interface ITaskRepository
    {
        Task AddTaskManagement(TaskManager taskModel);
        Task UpdateTaskManagement(TaskManager updatedTask);
        Task DeleteTask(Guid taskId);
        Task<List<TaskManager>> GetTasksForUser(Guid userId);
        Task<List<TaskManager>> GetAllTask();
    }
}
