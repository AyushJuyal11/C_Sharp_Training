using NotificationAPI.DAL.DbContexts;
using NotificationAPI.DAL.Entities;
using NotificationAPI.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NotificationAPI.DAL.Repositories.Implementations
{
    public class SendNotificationToDoRepository : ISendNotificationToDoRepository
    {

        private readonly AppDbContext _context;
        public SendNotificationToDoRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<SendNotificationToDo>> GetAllSendNotificationTodosAsync()
        {
            var viewEntities = await _context.SendNotificationToDos.Where(e => e.IsGenerated == false).ToListAsync();
            return viewEntities;
        }
    }
}
