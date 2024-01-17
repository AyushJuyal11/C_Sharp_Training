using ToDoList.Models.RequestViewModels;
using ToDoList.Models.ResponseViewModels;

namespace ToDoList.Services.Interfaces
{
    public interface IToDoItemService
    {
        Task<ToDoItemResponse> GetItemByIdAsync(int id);
        Task<ToDoItemResponse> DeleteItemByIdAsync(int id);

        Task<ToDoItemResponse> AddItemAsync(ToDoItemRequest item);

        Task<ToDoItemResponse> UpdateItemAsync(ToDoItemRequest item);
        Task<IEnumerable<ToDoItemResponse>> GetAllItemsAsync();
    }

}
