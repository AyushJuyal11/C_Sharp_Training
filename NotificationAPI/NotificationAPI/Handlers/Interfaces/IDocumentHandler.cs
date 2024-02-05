using NotificationAPI.DAL.Entities;

namespace NotificationAPI.Handlers.Interfaces
{
    public interface IDocumentHandler
    {
        void SetNext(IDocumentHandler nextHandler);
        Task HandleAsync(IDocumentHandler handler , SendNotificationToDo entity);

        abstract Task<int> ProcessRequestAsync(SendNotificationToDo entity);
    }
}
