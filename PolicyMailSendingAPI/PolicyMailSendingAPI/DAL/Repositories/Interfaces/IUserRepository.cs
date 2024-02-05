using PolicyMailSendingAPI.DAL.Entities;

namespace PolicyMailSendingAPI.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> AddUserAsync(UserEntity user); 
    }
}
