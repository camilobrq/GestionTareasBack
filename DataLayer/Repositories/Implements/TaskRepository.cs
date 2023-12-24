using DataLayer.Context;
using DataLayer.Repositories.Abstracts;
using EntityLayer.TaskModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Implements
{
    public class TaskRepository: ITaskRepository
    {
        private readonly GestionTareasDbContext context;

        public TaskRepository(GestionTareasDbContext context)
        {
            this.context = context;
        }

        public async Task AddTaskManagement(TaskManager taskModel)
        {
            var transaction = await context.Database.BeginTransactionAsync();

            context.Add(taskModel);
            await context.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        public async Task UpdateTaskManagement(TaskManager updatedTask)
        {
            var existingTask = await context.Tasks.FindAsync(updatedTask.idTask);

            if (existingTask != null)
            {
                existingTask.state = updatedTask.state;
                existingTask.description = updatedTask.description;
                existingTask.priority = updatedTask.priority;
                existingTask.taskTitle = updatedTask.taskTitle;
                existingTask.idUser = updatedTask.idUser;

                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteTask(Guid taskId)
        {
            var recipeToDelete = await context.Tasks.FindAsync(taskId);

            if (recipeToDelete != null)
            {
                context.Tasks.Remove(recipeToDelete);
                await context.SaveChangesAsync();
            }

        }

        public async Task<List<TaskManager>> GetTask(Guid taskId)
        {
            var recipe = await context.Tasks
        .Where(r => r.idTask == taskId)
        .ToListAsync();

            return recipe;
        }

        public async Task<List<TaskManager>> GetAllTask()
        {
            var recipes = await context.Tasks.ToListAsync();
            return recipes;
        }
    }
}
