using MimeKit;
using NotificationAPI.Services.Interfaces;
using MailKit.Net.Smtp; 

namespace NotificationAPI.Services.Implementations
{
    public class GenericMailService : IGenericMailService
    {
        public async Task<int> SendMailAsync(string destination, string from, string recepientName, string subject, MimeEntity body)
        {
            MimeMessage newEmail = new MimeMessage();
            newEmail.From.Add(new MailboxAddress("Ayush Juyal", from));
            newEmail.To.Add(new MailboxAddress(recepientName, destination));
            newEmail.Subject = subject;
            newEmail.Body = body; 
            
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync(from , "password : removed because repo is public");
                await client.SendAsync(newEmail); 
                client.Disconnect(true);
            }
            return 1; 
        }
    }
}
