using NotificationAPI.DAL.DbContexts;
using NotificationAPI.DAL.Repositories.Implementations;
using NotificationAPI.DAL.Repositories.Interfaces;
using NotificationAPI.Services.Implementations;
using NotificationAPI.Services.Interfaces;
using NotificationAPI.Utilities;
using Hangfire;
using Hangfire.Heartbeat;
using Hangfire.RecurringJobAdmin;
using Microsoft.EntityFrameworkCore;
using NotificationAPI.Handlers.Interfaces;
using NotificationAPI.Handlers.Implementations;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//HANGFIRE CONFIG
builder.Services.AddHangfire(configuration =>
{
    var con = builder.Configuration.GetConnectionString("DefaultConnection"); 
    configuration.UseSqlServerStorage(con); 
    configuration.UseHeartbeatPage(checkInterval: TimeSpan.FromSeconds(1));
    configuration.UseRecurringJobAdmin(typeof(Program).Assembly);
}
);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("name=DefaultConnection"));

builder.Services.AddScoped<IMyMailService, MyMailService>(); 
builder.Services.AddScoped<IUpdateFlagService ,  UpdateFlagService>();
builder.Services.AddScoped<IUserService , UserService>();
builder.Services.AddHttpClient<IHttpService ,  HttpService>();
builder.Services.AddScoped<IGenericMailService, GenericMailService>(); 
builder.Services.AddScoped<IGenericHttpService ,  GenericHttpService>();
builder.Services.AddScoped<IPrintService , PrintService>();
builder.Services.AddScoped<IDocumentHandler , UpdateFlagHandler>(); 
builder.Services.AddTransient<IDocumentHandler, MailHandler>(); 

builder.Services.AddTransient<IUserRepository, UserRepository>(); 
builder.Services.AddTransient<ISendNotificationToDoRepository , SendNotificationToDoRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddHangfireServer(); 

builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseHttpsRedirection();
app.UseHangfireDashboard("/dashboard");
app.MapControllers();

app.Run();
