using NotificationAPI.DAL.Entities;
using NotificationAPI.DAL.Repositories.Interfaces;
using NotificationAPI.Handlers.Implementations;
using NotificationAPI.Handlers.Interfaces;
using NotificationAPI.Services.Interfaces;

namespace NotificationAPI.Services.Implementations
{
    public class PrintService : IPrintService
    {
        private readonly IDocumentHandler _documentHandler;
        private readonly IServiceProvider serviceProvider1;
        private readonly ISendNotificationToDoRepository _sendToDoRepository; 
        public PrintService(IServiceProvider serviceProvider , ISendNotificationToDoRepository sendNotificationToDoRepository)
        {
            _documentHandler = serviceProvider.GetRequiredService<IDocumentHandler>();
            _sendToDoRepository  = sendNotificationToDoRepository; 
            serviceProvider1 = serviceProvider;
        }
        public async Task PrintAndSaveDocumentAsync()
        {
            MailHandler mailHandler = new MailHandler(serviceProvider1);
            UpdateFlagHandler updateFlagHandler = new UpdateFlagHandler(serviceProvider1);
            _documentHandler.SetNext(updateFlagHandler);
            var entities = await _sendToDoRepository.GetAllSendNotificationTodosAsync();
            foreach (SendNotificationToDo entity in entities)
            {
                try
                {
                    await _documentHandler.HandleAsync(mailHandler , entity); 
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    continue; 
                }
            }
            
        }
    }
}
