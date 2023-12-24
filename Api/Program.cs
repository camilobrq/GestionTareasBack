using AutoMapper;
using BussinesLayer.TaskLogics.Abstracts;
using BussinesLayer.TaskLogics.Implements;
using DataLayer.Context;
using DataLayer.Repositories.Abstracts;
using DataLayer.Repositories.Implements;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Donation API",
        Description = "API for Gestion de tareas",
    });

    // using System.Reflection;
    //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
//builder.Services.AddCorsService();
#region [Repositories]
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
#endregion

#region [Services]
builder.Services.AddScoped<ITaskManagement, TaskManagement>();
#endregion

#region [Connection DataBase]
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
builder.Services.AddDbContext<GestionTareasDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowAnyOrigin");

var service = app.Services.CreateScope().ServiceProvider
                .GetRequiredService<GestionTareasDbContext>();


//var s = service.Supervisors.ToList();

app.Run();
