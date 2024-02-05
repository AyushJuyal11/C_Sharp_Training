using NotificationAPI.DAL.Entities;

namespace NotificationAPI.Services.Interfaces
{
    public interface IMyMailService 
    {
        Task<int> SendMailAsync(SendNotificationToDo entity); 
    }
}
