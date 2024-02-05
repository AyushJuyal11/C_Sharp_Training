using Microsoft.EntityFrameworkCore;
using SoapConfigAPI.DAL.DbContexts;
using SoapConfigAPI.DAL.Repositories.Implementations;
using SoapConfigAPI.DAL.Repositories.Interfaces;
using SoapConfigAPI.Services.Implementations;
using SoapConfigAPI.Services.Interfaces;
using SoapConfigAPI.Utilities;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISoapConfigRepository, SoapConfigRepository>(); 
builder.Services.AddScoped<ISoapConfigService, SoapConfigService>(); 
builder.Services.AddDbContext<SoapConfigDbContext>(options => options.UseSqlServer("name=XMLDeserializeConnection"));
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

//logger config 
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();
