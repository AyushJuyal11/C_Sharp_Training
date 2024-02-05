namespace NotificationAPI.Handlers.Interfaces
{
    public interface IDocumentHandler
    {
        void SetNext(IDocumentHandler nextHandler);
        Task HandleAsync(IDocumentHandler handler);

        abstract Task<int> ProcessRequestAsync();
    }
}
