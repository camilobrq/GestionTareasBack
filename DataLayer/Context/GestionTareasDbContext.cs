using EntityLayer.StateModels;
using EntityLayer.TaskModels;
using EntityLayer.UserModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLayer.Context
{
    public class GestionTareasDbContext : DbContext
    {
        public GestionTareasDbContext(DbContextOptions<GestionTareasDbContext> dbContext) : base(dbContext)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>()
            .HavePrecision(18, 4);

            base.ConfigureConventions(configurationBuilder);
        }

        public DbSet<TaskManager> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<StateTask> StateTasks { get; set; }


    }
}
