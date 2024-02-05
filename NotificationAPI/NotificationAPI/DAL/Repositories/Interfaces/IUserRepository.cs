using NotificationAPI.DAL.Entities;

namespace NotificationAPI.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);

        Task<int> UpdateIsGeneratedFlagAsync(string PolicyNumber); 
    }
}
