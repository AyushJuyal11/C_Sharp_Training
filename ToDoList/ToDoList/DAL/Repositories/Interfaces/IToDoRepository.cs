using ToDoList.DAL.Entities;
using ToDoList.Models.RequestViewModels;

namespace ToDoList.DAL.Repositories.Interfaces
{
    public interface IToDoRepository
    {

        Task<IEnumerable<ToDoEntity>> GettingAllTasksAsync(); 
        Task<ToDoEntity> GetTaskByIdAsync(int id);
        Task<ToDoEntity> AddNewTaskAsync(ToDoEntity item);
        Task<ToDoEntity> DeletingTaskAsync(int id);
        Task<ToDoEntity> UpdatingTaskAsync(ToDoEntity item);
    }
}
