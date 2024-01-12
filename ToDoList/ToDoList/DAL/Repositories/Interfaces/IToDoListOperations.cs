using ToDoList.DAL.Entities; 

namespace ToDoList.DAL.Repositories.Interfaces
{
    public interface IToDoListOperations
    {

        Task<IEnumerable<ToDoItem>> GettingAllTasksAsync(); 
        Task<ToDoItem> GetTaskByIdAsync(int id);
        Task<int> AddNewTaskAsync(ToDoItem item);
        Task<int> DeletingTaskAsync(int id);
        Task<int> UpdatingTaskAsync(ToDoItem item);
    }
}
