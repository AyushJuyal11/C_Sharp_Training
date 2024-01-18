using Microsoft.EntityFrameworkCore;
using ToDoList.DAL.DbContexts;
using ToDoList.DAL.Repositories.Implementations;
using ToDoList.DAL.Repositories.Interfaces;
using ToDoList.Services.Implementations;
using ToDoList.Services.Interfaces;
using ToDoList.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddScoped<IToDoRepository, ToDoRepository>(); 
builder.Services.AddDbContext<ToDoApplicationContext>(options => options.UseSqlServer("name=ToDoApplicationConnection"));
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
