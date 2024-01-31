using PolicyMailSendingAPI.DAL.DbContexts;
using PolicyMailSendingAPI.DAL.Entities;
using PolicyMailSendingAPI.DAL.Repositories.Interfaces;

namespace PolicyMailSendingAPI.DAL.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> AddUserAsync(UserEntity user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
