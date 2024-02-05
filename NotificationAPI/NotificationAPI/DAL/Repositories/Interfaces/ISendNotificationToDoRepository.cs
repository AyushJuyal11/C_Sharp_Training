using NotificationAPI.DAL.Entities;

namespace NotificationAPI.DAL.Repositories.Interfaces
{
    public interface ISendNotificationToDoRepository
    {
        Task<IEnumerable<SendNotificationToDo>> GetAllSendNotificationTodosAsync();
        Task<int> UpdateIsGeneratedFlagAsync();
    }
}
