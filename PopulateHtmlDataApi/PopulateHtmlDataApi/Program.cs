using Microsoft.EntityFrameworkCore;
using PopulateHtmlDataApi.DAL.DbContexts;
using PopulateHtmlDataApi.DAL.Repositories.Implementations;
using PopulateHtmlDataApi.DAL.Repositories.Interfaces;
using PopulateHtmlDataApi.Services.Implementations;
using PopulateHtmlDataApi.Services.Interfaces;
using PopulateHtmlDataApi.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>(); 
builder.Services.AddTransient<IAddDocumentService , AddDocumentService>();
builder.Services.AddTransient<IHtmlTemplateService , HtmlTemplateService>();
builder.Services.AddTransient<IConvertToPdfService , ConvertToPdfService>();
builder.Services.AddTransient<IPopulateHtmlDataService , PopulateHtmlDataService>();
builder.Services.AddTransient<IEPolicyKitDocumentGenerationService, EPolicyKitDocumentGenerationService>();
builder.Services.AddTransient<IUserRepository, UserRepository>(); 
builder.Services.AddTransient<IDocumentRepository , DocumentRepository>();
builder.Services.AddTransient<IHtmlTemplateRepository , HtmlTemplateRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("name=PopulateHtmlConnectionString"));
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
