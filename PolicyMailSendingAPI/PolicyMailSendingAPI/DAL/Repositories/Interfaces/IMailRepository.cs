using PolicyMailSendingAPI.DAL.Entities;

namespace PolicyMailSendingAPI.DAL.Repositories.Interfaces
{
    public interface IMailRepository
    {
        Task<IEnumerable<ViewEntity>> GetAllMailAddressesAsync();
        Task<int> ChangeIsGeneratedFlagAsync(string PolicyNumber); 
    }
}
