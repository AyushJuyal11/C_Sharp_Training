using SoapConfigAPI.Models.RequestViewModels;
using SoapConfigAPI.Models.ResponseViewModels;

namespace SoapConfigAPI.Services.Interfaces
{
    public interface ISoapConfigService
    {
        Task<IEnumerable<UserResponseModel>> GetSoapConfigByIdAsync(int ID);
        Task<IEnumerable<UserResponseModelList>> GetAllSoapConfigsAsync(); 
        Task<int> AddSoapConfigAsync(SoapConfigRequest file);
        Task<int> UpdateSoapConfigAsync(SoapConfigRequest file);
        Task<int> DeleteSoapConfigAsync(int ID);
    }
}
