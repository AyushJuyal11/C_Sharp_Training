using NotificationAPI.Services.Interfaces;

namespace NotificationAPI.Handlers.Implementations
{
    public class UpdateFlagHandler : DocumentHandler
    {
        private readonly IUpdateFlagService _updateFlagService;
        public UpdateFlagHandler(IServiceProvider serviceProvider) {
            _updateFlagService = serviceProvider.GetRequiredService<IUpdateFlagService>(); 
        }
        public async override Task<int> ProcessRequestAsync()
        {
            int result = await _updateFlagService.UpdateIsGeneratedFlagAsync();
            return result;
        }
    }
}
