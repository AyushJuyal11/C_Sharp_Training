using Microsoft.EntityFrameworkCore;
using SoapConfigAPI.DAL.DbContexts;
using SoapConfigAPI.DAL.Entities;
using SoapConfigAPI.DAL.Repositories.Interfaces;

namespace SoapConfigAPI.DAL.Repositories.Implementations
{
    public class SoapConfigRepository(SoapConfigDbContext context) : ISoapConfigRepository
    {
        private readonly SoapConfigDbContext _context = context;

        public async Task<SoapConfig> AddSoapConfigAsync(SoapConfig fileToAdd)
        {
            fileToAdd.CreationDateTime = DateTime.UtcNow; 
            fileToAdd.ModifiedDateTime = DateTime.UtcNow;
            _context.Add(fileToAdd);
            await _context.SaveChangesAsync();
            return fileToAdd; 
        }

        public async Task<SoapConfig> DeleteSoapConfigAsync(int ID)
        {
            SoapConfig? fileToBeDeleted = await _context.SoapConfigs.FindAsync(ID);
            _context.Remove(fileToBeDeleted);
            await _context.SaveChangesAsync();
            return fileToBeDeleted;
        }

        public async Task<IEnumerable<SoapConfig>> GetAllSoapConfigsAsync()
        {
            List<SoapConfig> allXmlFiles = await _context.SoapConfigs.ToListAsync();
            return allXmlFiles;
        }

        public async Task<SoapConfig> GetSoapConfigByIdAsync(int ID)
        {
            SoapConfig? requiredFile = await _context.SoapConfigs.FindAsync(ID);
            return requiredFile;
        }

        public async Task<SoapConfig> UpdateSoapConfigAsync(SoapConfig updatedFile)
        {
            SoapConfig? fileToBeUpdated = await _context.SoapConfigs.FindAsync(updatedFile.ID);
            fileToBeUpdated.ID = updatedFile.ID;
            fileToBeUpdated.XML = updatedFile.XML;
            fileToBeUpdated.Code = updatedFile.Code;
            fileToBeUpdated.ModifiedDateTime = DateTime.UtcNow;
            fileToBeUpdated.CreationDateTime = updatedFile.CreationDateTime;
            await _context.SaveChangesAsync();
            return fileToBeUpdated;
        }
    }
}
