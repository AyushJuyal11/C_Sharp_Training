using ToDoList.DAL.Entities; 

namespace ToDoList.DAL.Repositories.Interfaces
{
    public interface ITaskOperations
    {

        IEnumerable<Entities.Task> GetAllTasks(); 
        Entities.Task GetTaskById(int id);
        int AddNewTask(Entities.Task item);
        int DeleteTask(int id);
        int UpdateTask(Entities.Task item);
    }
}
