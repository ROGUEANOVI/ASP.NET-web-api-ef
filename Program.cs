using Microsoft.EntityFrameworkCore;
using WebApiEF.DbContexts;
using WebApiEF.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuracion de Entity Framework

var conString = builder.Configuration.GetConnectionString("CsTasksDb");
builder.Services.AddDbContext<TaskContext>(options => options.UseSqlServer(conString));

// builder.Services.AddSqlServer<TaskContext>(builder.Configuration.GetConnectionString ("CsTasksDb"));

// Inyectando servicios de Task y Category
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITaskService, TaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
