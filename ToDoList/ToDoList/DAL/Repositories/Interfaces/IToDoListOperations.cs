using ToDoList.DAL.Entities;
using ToDoList.Models.RequestViewModels;

namespace ToDoList.DAL.Repositories.Interfaces
{
    public interface IToDoListOperations
    {

        Task<IEnumerable<ToDoItem>> GettingAllTasksAsync(); 
        Task<ToDoItem> GetTaskByIdAsync(int id);
        Task<ToDoItem> AddNewTaskAsync(ToDoItem item);
        Task<ToDoItem> DeletingTaskAsync(int id);
        Task<ToDoItem> UpdatingTaskAsync(ToDoItem item);
    }
}
