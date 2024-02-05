using NotificationAPI.Models.RequestViewModels;

namespace NotificationAPI.Services.Interfaces
{
    public interface IHttpService
    {
        Task<int> SendUserData(UserRequestModel user); 
    }
}
