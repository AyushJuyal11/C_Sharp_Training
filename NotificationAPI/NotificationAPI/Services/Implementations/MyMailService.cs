using NotificationAPI.Services.Interfaces;
using NotificationAPI.DAL.Entities;
using MimeKit;

namespace NotificationAPI.Services.Implementations
{
    public class MyMailService : IMyMailService
    {

        private readonly IGenericMailService _genericMailService;
        private readonly string from;
        public MyMailService(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _genericMailService = serviceProvider.GetRequiredService<IGenericMailService>();
            from = configuration["DocumentAPISettings:Sender"];
        }

        public async Task<int> SendMailAsync(SendNotificationToDo entity)
        {
            string subject = "Policy Document Generated";
            string body = "Please check your policy pdf attached with this email";

            string destination = entity.Email;
            var builder = new BodyBuilder();
            builder.TextBody = body;
            File.WriteAllBytes("policy.pdf", entity.Content);
            builder.Attachments.Add("policy.pdf");
            MimeEntity Body = builder.ToMessageBody();
            int result = await _genericMailService.SendMailAsync(destination, from, entity.Name, subject, Body);
            File.Delete("policy.pdf"); 
            return result; 
        }
    }
}

