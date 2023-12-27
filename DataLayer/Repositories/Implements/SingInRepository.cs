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
    public class SingInRepository: ISingInRepository
    {
        private readonly GestionTareasDbContext context;

        public SingInRepository(GestionTareasDbContext context)
        {
            this.context = context;
        }

        public async Task<List<TUser>> GetUser(string username, string password)
        {
            var user = await context.Users
            .Where(r => r.email == username && r.password ==password)
            .ToListAsync();

            return user;
        }
        public async Task<List<TUser>> ValidateUsername(string username)
        {
            var user = await context.Users
            .Where(r => r.email == username)
            .ToListAsync();

            return user;
        }
        public async Task RegisterUser(TUser userModel)
        {
            var transaction = await context.Database.BeginTransactionAsync();

            context.Add(userModel);
            await context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
    }
}
