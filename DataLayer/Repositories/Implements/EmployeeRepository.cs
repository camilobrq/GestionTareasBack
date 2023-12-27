using DataLayer.Context;
using DataLayer.Repositories.Abstracts;
using EntityLayer.AuthModels;
using EntityLayer.TaskModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Implements
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly GestionTareasDbContext context;

        public EmployeeRepository(GestionTareasDbContext context)
        {
            this.context = context;
        }

        public async Task<List<UserModelResponse>> GetAllUser()
        {
            var userModelResponse = await context.Users
            .Select(u => new UserModelResponse
            {
                idUser = u.idUser,
                name = u.name,
                lastName = u.lastName,
            })
            .ToListAsync();
            return userModelResponse;
        }
    }
}
