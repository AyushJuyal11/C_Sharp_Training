using NotificationAPI.Services.Interfaces;

namespace NotificationAPI.Handlers.Implementations
{
    public class MailHandler : DocumentHandler
    {
        private readonly IMyMailService _myMailService;
        public MailHandler(IServiceProvider serviceProvider) 
        {
            _myMailService = serviceProvider.GetRequiredService<IMyMailService>(); 
        }

        public async override Task<int> ProcessRequestAsync()
        {
            int result = await _myMailService.SendMailAsync(); 
            return result;
        }

    }
}
