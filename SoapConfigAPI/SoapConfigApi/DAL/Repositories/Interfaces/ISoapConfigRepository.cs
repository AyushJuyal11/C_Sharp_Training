using SoapConfigAPI.DAL.Entities;

namespace SoapConfigAPI.DAL.Repositories.Interfaces
{
    public interface ISoapConfigRepository
    {
        public Task<IEnumerable<SoapConfig>> GetAllSoapConfigsAsync();
        public Task<SoapConfig> AddSoapConfigAsync(SoapConfig fileDetails);
        public Task<SoapConfig> UpdateSoapConfigAsync(SoapConfig fileDetails);
        public Task<SoapConfig> DeleteSoapConfigAsync(int ID); 
        public Task<SoapConfig> GetSoapConfigByIdAsync(int ID); 
    }
}
