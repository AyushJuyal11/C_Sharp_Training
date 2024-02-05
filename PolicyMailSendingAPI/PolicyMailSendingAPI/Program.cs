using PolicyMailSendingAPI.DAL.DbContexts;
using PolicyMailSendingAPI.DAL.Repositories.Implementations;
using PolicyMailSendingAPI.DAL.Repositories.Interfaces;
using PolicyMailSendingAPI.Services.Implementations;
using PolicyMailSendingAPI.Services.Interfaces;
using PolicyMailSendingAPI.Utilities;
using Hangfire;
using Hangfire.Heartbeat;
using Hangfire.RecurringJobAdmin;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); 
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//HANGFIRE CONFIG
builder.Services.AddHangfire(configuration =>
{
    configuration.UseSqlServerStorage("Server=.;Database=HangFireDemo; Integrated Security = True; TrustServerCertificate = True;");
    configuration.UseHeartbeatPage(checkInterval: TimeSpan.FromSeconds(1));
    configuration.UseRecurringJobAdmin(typeof(Program).Assembly);
}
);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("name=DefaultConnection"));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDocumentGenerationService , DocumentGenerationService>();
builder.Services.AddScoped<IMailSendingService , MailSendingService>();
builder.Services.AddTransient<IUserRepository, UserRepository>(); 
builder.Services.AddTransient<IMailRepository , MailRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddHttpClient<DocumentGenerationService>(); 
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
