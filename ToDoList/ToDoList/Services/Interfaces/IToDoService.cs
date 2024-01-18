using ToDoList.Models.RequestViewModels;
using ToDoList.Models.ResponseViewModels;

namespace ToDoList.Services.Interfaces
{
    public interface IToDoService
    {
        Task<ToDoResponse> GetItemByIdAsync(int id);
        Task<ToDoResponse> DeleteItemByIdAsync(int id);
        Task<ToDoResponse> AddItemAsync(ToDoRequest item);
        Task<ToDoResponse> UpdateItemAsync(ToDoRequest item);
        Task<IEnumerable<ToDoResponse>> GetAllItemsAsync();
    }

}
