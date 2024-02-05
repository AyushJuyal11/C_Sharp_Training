using NotificationAPI.Models.RequestViewModels;

namespace NotificationAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<int> AddUserAsync(UserRequestModel user); 
    }
}
