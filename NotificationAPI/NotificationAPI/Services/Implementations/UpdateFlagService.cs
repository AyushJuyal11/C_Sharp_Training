using NotificationAPI.DAL.Repositories.Interfaces;
using NotificationAPI.Services.Interfaces;

namespace NotificationAPI.Services.Implementations
{
    public class UpdateFlagService : IUpdateFlagService
    {
        private readonly ISendNotificationToDoRepository _sendNotificationToDoRepository;

        public UpdateFlagService(ISendNotificationToDoRepository sendNotificationToDoRepository)
        {
            _sendNotificationToDoRepository=sendNotificationToDoRepository;
        }

        public async Task<int> UpdateIsGeneratedFlagAsync()
        {
            int result = await _sendNotificationToDoRepository.UpdateIsGeneratedFlagAsync();
            return result; 
        }
    }
}
