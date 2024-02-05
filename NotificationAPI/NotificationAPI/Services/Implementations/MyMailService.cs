using NotificationAPI.Services.Interfaces;
using NotificationAPI.DAL.Entities;
using NotificationAPI.DAL.Repositories.Interfaces;
using MimeKit;

namespace NotificationAPI.Services.Implementations
{
    public class MyMailService : IMyMailService
    {

        private readonly ISendNotificationToDoRepository _sendNotificationToDoRepository;
        private readonly IGenericMailService _genericMailService; 
        public MyMailService(ISendNotificationToDoRepository mailRepository, IServiceProvider serviceProvider)
        {
            _sendNotificationToDoRepository = mailRepository;
            _genericMailService = serviceProvider.GetRequiredService<IGenericMailService>(); 
        }

        public async Task<int> SendMailAsync()
        {
            List<SendNotificationToDo> entities = (List<SendNotificationToDo>)await _sendNotificationToDoRepository.GetAllSendNotificationTodosAsync();
            string subject = "Policy Document Generated";
            string body = "Please check your policy pdf attached with this email";
            string from = "ayushjuyal246@gmail.com"; 

            foreach (SendNotificationToDo entity in entities)
            {
                string to = entity.Email; 
                var builder = new BodyBuilder();
                builder.TextBody = body; 
                File.WriteAllBytes("policy.pdf", entity.Content);
                builder.Attachments.Add("policy.pdf");
                MimeEntity Body = builder.ToMessageBody();
                var result = await _genericMailService.SendMailAsync(to , from , entity.Name , subject , Body); 
            }
            return 1; 
        }

    }
}
