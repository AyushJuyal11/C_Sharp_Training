using PolicyMailSendingAPI.Services.Interfaces;
using PolicyMailSendingAPI.DAL.Entities;
using PolicyMailSendingAPI.DAL.Repositories.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace PolicyMailSendingAPI.Services.Implementations
{
    public class MailSendingService : IMailSendingService
    {

        private readonly IMailRepository _mailRepository;
        public MailSendingService(IMailRepository mailRepository)
        {
            _mailRepository = mailRepository;
        }
        public async Task SendMailAsync()
        {

            List<ViewEntity> entities = (List<ViewEntity>)await _mailRepository.GetAllMailAddressesAsync();
            MimeMessage newEmail = new MimeMessage();
            newEmail.From.Add(new MailboxAddress("Ayush Juyal", "ayushjuyal246@gmail.com")); 
            foreach(ViewEntity entity in entities)
            {
                newEmail.To.Add(new MailboxAddress(entity.Name , entity.Email));
                newEmail.Subject = "Policy Document Generated";
                File.WriteAllBytes("policy.pdf", entity.Content); 
                var builder = new BodyBuilder();
                builder.TextBody = "Please check your policy pdf and if there's any problem don't disturb us on weekends :)";
                builder.Attachments.Add("policy.pdf"); 
                newEmail.Body = builder.ToMessageBody();

                using(var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("ayushjuyal246@gmail.com", "tbfj lfxe mdnq dovi"); 
                    client.Send(newEmail);
                    client.Disconnect(true); 
                    var changedEntity = await _mailRepository.ChangeIsGeneratedFlagAsync(entity.PolicyNumber);
                }
            }
        }
    }
}
