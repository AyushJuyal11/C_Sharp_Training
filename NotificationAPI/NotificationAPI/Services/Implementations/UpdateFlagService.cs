using NotificationAPI.DAL.Repositories.Interfaces;
using NotificationAPI.Services.Interfaces;

namespace NotificationAPI.Services.Implementations
{
    public class UpdateFlagService : IUpdateFlagService
    {
        private readonly IUserRepository _userRepository;

        public UpdateFlagService(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }

        public async Task<int> UpdateIsGeneratedFlagAsync(string PolicyNumber)
        {
            int result = await _userRepository.UpdateIsGeneratedFlagAsync(PolicyNumber);
            return result; 
        }
    }
}
