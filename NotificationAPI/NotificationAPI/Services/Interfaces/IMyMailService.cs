namespace NotificationAPI.Services.Interfaces
{
    public interface IMyMailService 
    {
        Task<int> SendMailAsync(); 
    }
}
