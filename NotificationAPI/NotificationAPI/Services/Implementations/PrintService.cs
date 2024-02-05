using NotificationAPI.Handlers.Implementations;
using NotificationAPI.Handlers.Interfaces;
using NotificationAPI.Services.Interfaces;

namespace NotificationAPI.Services.Implementations
{
    public class PrintService : IPrintService
    {
        private readonly IDocumentHandler _documentHandler;
        private readonly IServiceProvider serviceProvider1;
        public PrintService(IServiceProvider serviceProvider)
        {
            _documentHandler = serviceProvider.GetRequiredService<IDocumentHandler>(); 
            serviceProvider1 = serviceProvider;
        }
        public async Task InitiateRequestAsync()
        {
            MailHandler mailHandler = new MailHandler(serviceProvider1); 
            UpdateFlagHandler updateFlagHandler = new UpdateFlagHandler(serviceProvider1);
            _documentHandler.SetNext(updateFlagHandler); 
            await _documentHandler.HandleAsync(mailHandler); 
        }
    }
}
