using NotificationAPI.DAL.DbContexts;
using NotificationAPI.DAL.Entities;
using NotificationAPI.DAL.Repositories.Interfaces;

namespace NotificationAPI.DAL.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
