using MimeKit;

namespace NotificationAPI.Services.Interfaces
{
    public interface IGenericMailService
    {
        Task<int> SendMailAsync(string to , string from , string recepientName ,  string subject, MimeEntity body);
    }
}
