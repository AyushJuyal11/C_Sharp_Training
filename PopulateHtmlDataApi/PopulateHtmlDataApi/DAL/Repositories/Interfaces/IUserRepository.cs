using PopulateHtmlDataApi.DAL.Entities;

namespace PopulateHtmlDataApi.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<UserEntity>> GetAllUserEntitiesAsync();
        public Task<UserEntity> AddUserEntityAsync(UserEntity userDetails);
        public Task<UserEntity> UpdateUserEntityAsync(UserEntity userDetails);
        public Task<UserEntity> DeleteUserEntityAsync(string policyNumber);
        public Task<UserEntity> GetUserEntityByIdAsync(string policyNumber);
    }
}
