using Microsoft.EntityFrameworkCore;
using SoapConfigAPI.DAL.DbContexts;
using SoapConfigAPI.DAL.Entities;
using SoapConfigAPI.DAL.Repositories.Interfaces;

namespace SoapConfigAPI.DAL.Repositories.Implementations
{
    public class SoapConfigRepository(SoapConfigDbContext context) : ISoapConfigRepository
    {
        private readonly SoapConfigDbContext _context = context;

        public async Task<SoapConfig> AddSoapConfigAsync(SoapConfig soapConfigToAdd)
        {
            soapConfigToAdd.CreationDateTime = DateTime.UtcNow; 
            soapConfigToAdd.ModifiedDateTime = DateTime.UtcNow;
            _context.Add(soapConfigToAdd);
            await _context.SaveChangesAsync();
            return soapConfigToAdd; 
        }

        public async Task<SoapConfig> DeleteSoapConfigAsync(int ID)
        {
            SoapConfig? soapConfigToBeDeleted = await _context.SoapConfigs.FindAsync(ID);
            _context.Remove(soapConfigToBeDeleted);
            await _context.SaveChangesAsync();
            return soapConfigToBeDeleted;
        }

        public async Task<IEnumerable<SoapConfig>> GetAllSoapConfigsAsync()
        {
            List<SoapConfig> allXmlSoapConfigs = await _context.SoapConfigs.ToListAsync();
            return allXmlSoapConfigs;
        }

        public async Task<SoapConfig> GetSoapConfigByIdAsync(int ID)
        {
            SoapConfig? requiredSoapConfig = await _context.SoapConfigs.FindAsync(ID);
            return requiredSoapConfig;
        }

        public async Task<SoapConfig> UpdateSoapConfigAsync(SoapConfig updatedSoapConfig)
        {
            SoapConfig? soapConfigToBeUpdated = await _context.SoapConfigs.FindAsync(updatedSoapConfig.ID);
            soapConfigToBeUpdated.ID = updatedSoapConfig.ID;
            soapConfigToBeUpdated.XML = updatedSoapConfig.XML;
            soapConfigToBeUpdated.Code = updatedSoapConfig.Code;
            soapConfigToBeUpdated.ModifiedDateTime = DateTime.UtcNow;
            soapConfigToBeUpdated.CreationDateTime = updatedSoapConfig.CreationDateTime;
            await _context.SaveChangesAsync();
            return soapConfigToBeUpdated;
        }
    }
}
