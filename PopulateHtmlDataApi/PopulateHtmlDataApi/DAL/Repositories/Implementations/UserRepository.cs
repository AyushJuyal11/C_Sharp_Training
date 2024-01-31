using Microsoft.EntityFrameworkCore;
using PopulateHtmlDataApi.DAL.DbContexts;
using PopulateHtmlDataApi.DAL.Entities;
using PopulateHtmlDataApi.DAL.Repositories.Interfaces;

namespace PopulateHtmlDataApi.DAL.Repositories.Implementations
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<UserEntity> AddUserEntityAsync(UserEntity userToAdd)
        {
            _context.Add(userToAdd);
            await _context.SaveChangesAsync();
            return userToAdd;
        }

        public async Task<UserEntity> DeleteUserEntityAsync(string PolicyNumber)
        {
            UserEntity? userToBeDeleted = await _context.Users.FindAsync(PolicyNumber);
            _context.Users.Remove(userToBeDeleted);
            await _context.SaveChangesAsync();
            return userToBeDeleted;
        }

        public async Task<IEnumerable<UserEntity>> GetAllUserEntitiesAsync()
        {
            List<UserEntity> allUserEntities = await _context.Users.ToListAsync();
            return allUserEntities;
        }

        public async Task<UserEntity> GetUserEntityByIdAsync(string PolicyNumber) 
        {
            UserEntity? requiredUserEntity = await _context.Users.FindAsync(PolicyNumber);
            return requiredUserEntity;
        }

        public async Task<UserEntity> UpdateUserEntityAsync(UserEntity updatedUserEntity)
        {
            UserEntity? userToBeUpdated = await _context.Users.FindAsync(updatedUserEntity.PolicyNumber);
            userToBeUpdated.PolicyNumber = updatedUserEntity.PolicyNumber;
            userToBeUpdated.PolicyExpirationDate = updatedUserEntity.PolicyExpirationDate;
            userToBeUpdated.Age = updatedUserEntity.Age;
            userToBeUpdated.ProductCode = updatedUserEntity.ProductCode;
            userToBeUpdated.Salary = updatedUserEntity.Salary;
            userToBeUpdated.Name = updatedUserEntity.Name;
            userToBeUpdated.Email = updatedUserEntity.Email;
            userToBeUpdated.Occupation  = updatedUserEntity.Occupation;
            await _context.SaveChangesAsync();
            return userToBeUpdated;
        }
    }
}
