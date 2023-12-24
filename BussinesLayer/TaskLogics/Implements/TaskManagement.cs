using AutoMapper;
using BusinessLayer.ResponseModels;
using BussinesLayer.TaskLogics.Abstracts;
using CommonsLayer.DTO.TaskManagement;
using DataLayer.Repositories.Abstracts;
using EntityLayer.TaskModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.TaskLogics.Implements
{
    public class TaskManagement: ITaskManagement
    {
        private readonly ITaskRepository repository;
        private readonly IMapper mapper;
        private readonly IMapper _mapper;

        
        public TaskManagement(ITaskRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Response> RegisterTask(TaskCreateDto task)
        {
            try
            {

                TaskManager taskModel = new TaskManager();
                taskModel.idTask = Guid.NewGuid();
                taskModel.taskTitle = task.taskTitle;
                taskModel.description = task.description;
                taskModel.state = task.state;
                taskModel.priority = task.priority;
                taskModel.idUser = task.idUser;
                await repository.AddTaskManagement(taskModel);

                return Response.Successful("Successful");
            }
            catch (Exception)
            {
                return Response.Error("Ha ocurrido un error, no se ha podido registrar el evento.");
            }
        }
        public async Task<Response> UpdateTask(TaskCreateDto task)
        {
            try
            {
                TaskManager taskModel = new TaskManager();
                taskModel.idTask = task.idTask;
                taskModel.taskTitle = task.taskTitle;
                taskModel.description = task.description;
                taskModel.state = task.state;
                taskModel.priority = task.priority;
                taskModel.idUser = task.idUser;
                await repository.UpdateTaskManagement(taskModel);

                return Response.Successful("Successful");
            }
            catch (Exception e)
            {
                return Response.Error("Ha ocurrido un error, no se ha podido registrar el evento.");
            }
        }

        public async Task<Response<List<TaskManager>>> GetTasks(Guid taskId)
        {
            try
            {

                var result = await repository.GetTask(taskId);

                return Response<List<TaskManager>>.Successful("Successful", result);

            }
            catch (Exception)
            {
                return Response<List<TaskManager>>.Error("Ha ocurrido un error, no se ha podido registrar el evento.", null);
            }
        }
        public async Task<Response> DeleteTask(Guid taskId)
        {
            try
            {

                await repository.DeleteTask(taskId);

                return Response.Successful("Successful");
            }
            catch (Exception)
            {
                return Response.Error("Ha ocurrido un error, no se ha podido registrar el evento.");
            }
        }

        public async Task<Response<List<TaskManager>>> GetAllTask()
        {
            try
            {

                var result = await repository.GetAllTask();

                return Response<List<TaskManager>>.Successful("Successful", result);

            }
            catch (Exception)
            {
                return Response<List<TaskManager>>.Error("Ha ocurrido un error, no se ha podido registrar el evento.", null);
            }
        }


    }
}
