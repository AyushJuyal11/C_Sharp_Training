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
        public abstract Task<int> ProcessRequestAsync();

        public async Task HandleAsync(IDocumentHandler handler)
        {
            await handler.ProcessRequestAsync(); 
            if(nextHandler != null) {
                await HandleAsync(nextHandler);
            }
        }
    }
}
