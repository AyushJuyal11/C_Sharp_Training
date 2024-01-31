using PolicyMailSendingAPI.Models.RequestViewModels;

namespace PolicyMailSendingAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<int> AddUserAsync(UserRequestModel user); 
    }
}
