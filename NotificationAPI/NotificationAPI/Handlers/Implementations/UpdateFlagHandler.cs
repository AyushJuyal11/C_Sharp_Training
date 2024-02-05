using NotificationAPI.DAL.Entities;
using NotificationAPI.Services.Interfaces;

namespace NotificationAPI.Handlers.Implementations
{
    public class UpdateFlagHandler : DocumentHandler
    {
        private readonly IUpdateFlagService _updateFlagService;
        public UpdateFlagHandler(IServiceProvider serviceProvider) {
            _updateFlagService = serviceProvider.GetRequiredService<IUpdateFlagService>(); 
        }
        public async override Task<int> ProcessRequestAsync(SendNotificationToDo entity) 
        {
            int result = await _updateFlagService.UpdateIsGeneratedFlagAsync(entity.PolicyNumber);
            return result;
        }
    }
}
