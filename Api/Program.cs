using Api.Infrastructure.Helpers;
using AutoMapper;
using BussinesLayer.AuthLogic.Abstracts;
using BussinesLayer.AuthLogic.Implements;
using BussinesLayer.TaskLogics.Abstracts;
using BussinesLayer.TaskLogics.Implements;
using CommonsLayer.Configuration;
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

});
builder.Services.AddCorsService();

#region [Repositories]
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ISingInRepository, SingInRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
#endregion

#region [Services]
builder.Services.AddScoped<ITaskManagement, TaskManagement>();
builder.Services.AddScoped<ISingInManagement, SingInManagement>();
builder.Services.AddScoped<IEmployeeManagement, EmployeeManagement>();
#endregion

#region Jwt
builder.Services.Configure<JwtTokenProviderOptions>(builder.Configuration.GetSection("SecretKey"));
builder.Services.AddJsonTokenProvider(builder.Configuration);
builder.Services.AddAuthenticationService(builder.Configuration);
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
