using PolicyMailSendingAPI.DAL.DbContexts;
using PolicyMailSendingAPI.DAL.Entities;
using PolicyMailSendingAPI.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PolicyMailSendingAPI.DAL.Repositories.Implementations
{
    public class MailRepository : IMailRepository
    {

        private readonly AppDbContext _context;
        public MailRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<ViewEntity>> GetAllMailAddressesAsync()
        {
            var viewEntities = await _context.ViewEntities.Where(e => e.IsGenerated == false).ToListAsync();
            return viewEntities;
        }
        public async Task<int> ChangeIsGeneratedFlagAsync(string PolicyNumber)
        {
            var requiredEntity = await _context.Users.Where(e => e.PolicyNumber == PolicyNumber).FirstOrDefaultAsync();
            requiredEntity.IsGenerated = true; 
            await _context.SaveChangesAsync();
            return 1; 
        }

    }
}
