using NotificationAPI.DAL.Entities;
using NotificationAPI.Handlers.Interfaces;

namespace NotificationAPI.Handlers.Implementations
{
    public abstract class DocumentHandler : IDocumentHandler
    {
        protected IDocumentHandler nextHandler;

        public void SetNext(IDocumentHandler nextHandler) 
        {
            this.nextHandler = nextHandler;
        }
        public abstract Task<int> ProcessRequestAsync(SendNotificationToDo entity);

        public async Task HandleAsync(IDocumentHandler handler , SendNotificationToDo entity)
        {
            await handler.ProcessRequestAsync(entity); 
            if(nextHandler != null) {
                await HandleAsync(nextHandler, entity);
            }
        }
    }
}
