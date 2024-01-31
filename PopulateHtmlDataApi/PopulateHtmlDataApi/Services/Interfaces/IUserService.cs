using PopulateHtmlDataApi.Models.RequestViewModels;
using PopulateHtmlDataApi.Models.ResponseViewModels;

namespace PopulateHtmlDataApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseModel> GetUserByPolicyNumberAsync(string PolicyNumber); 
        Task<IEnumerable<UserResponseModel>> GetAllUsersAsync();
        Task<int> AddUserAsync(UserRequestModel htmlTemplate);
        Task<int> UpdateUserAsync(UserRequestModel htmlTemplate);
        Task<int> DeleteUserAsync(string PolicyNumber); 

    }
}
