using ToDoList.DAL.Entities;
using ToDoList.DAL.Repositories.Interfaces;
using Newtonsoft.Json;
using ToDoList.DAL.JsonFile;
using Newtonsoft.Json.Linq;

namespace ToDoList.DAL.Repositories.Implementations
{
    public class ToDoListOperations : IToDoListOperations
    {
        public async Task<IEnumerable<ToDoItem>> GettingAllTasksAsync()
        {
            var toDoItemsJsonString = await File.ReadAllTextAsync(JsonFilePath.path);
            List<ToDoItem> toDoItemEntities = new(); 
            if(toDoItemsJsonString == null) return toDoItemEntities;

            toDoItemEntities = JsonConvert.DeserializeObject<List<ToDoItem>>(toDoItemsJsonString); 
            return toDoItemEntities;
        }


        public async Task<ToDoItem> GetTaskByIdAsync(int id)
        {
            var toDoItemsJsonString = await File.ReadAllTextAsync(JsonFilePath.path);
            var toDoItemEntities = JsonConvert.DeserializeObject<List<ToDoItem>>(toDoItemsJsonString);

            if(toDoItemEntities.Count == 0) 
                return new ToDoItem();

            else
                return toDoItemEntities.Where(t => t.Id == id).FirstOrDefault();
        }

        public async Task<int> AddNewTaskAsync(ToDoItem task)
        {
            if(task.Id < 0 ||  task.Id > int.MaxValue)
            {
                return -1; 
            }

            var toDoItemsJsonString = await File.ReadAllTextAsync(JsonFilePath.path);

            var toDoItemEntities = JsonConvert.DeserializeObject<List<ToDoItem>>(toDoItemsJsonString) ?? new List<ToDoItem>();

            var ifTaskExists = toDoItemEntities.Where((t) => t.Id == task.Id).FirstOrDefault();
            if (ifTaskExists != null) return -1; 


            toDoItemEntities.Add(task);
            toDoItemsJsonString = JsonConvert.SerializeObject(toDoItemEntities , Formatting.Indented);
            File.WriteAllText(JsonFilePath.path, toDoItemsJsonString);
            return 1; 
        }


        public async Task<int> DeletingTaskAsync(int id)
        {
            if (id < 0 || id > int.MaxValue) return -1; 
            var toDoItemsJsonString = await File.ReadAllTextAsync(JsonFilePath.path);
            var toDoItemEntities = JsonConvert.DeserializeObject<List<ToDoItem>>(toDoItemsJsonString);
            if(toDoItemEntities.Count == 0) return -1; 

            var taskToRemove = toDoItemEntities.Where(t => t.Id == id).FirstOrDefault();
            if (taskToRemove == null) return -1; 

            toDoItemEntities.Remove(taskToRemove);
            toDoItemsJsonString = JsonConvert.SerializeObject(toDoItemEntities); 
            File.WriteAllText(JsonFilePath.path, toDoItemsJsonString);
            return 1; 
        }
        
        public async Task<int> UpdatingTaskAsync(ToDoItem task)
        {
            var toDoItemsJsonString = await File.ReadAllTextAsync(JsonFilePath.path);
            var toDoItemEntities = JsonConvert.DeserializeObject<List<ToDoItem>>(toDoItemsJsonString);
            if (toDoItemEntities.Count == 0) return -1; 

            var taskToUpdate = toDoItemEntities.Where(t => t.Id == task.Id).FirstOrDefault();
            if(taskToUpdate == null) return -1;
            toDoItemEntities.Remove(taskToUpdate);
            toDoItemEntities.Add(task); 

            toDoItemsJsonString = JsonConvert.SerializeObject(toDoItemEntities);
            File.WriteAllText(JsonFilePath.path, toDoItemsJsonString); 
            return 1; 
        }
    }
}
