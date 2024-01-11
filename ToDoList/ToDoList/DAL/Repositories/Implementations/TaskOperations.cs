using ToDoList.DAL.Entities;
using ToDoList.DAL.Repositories.Interfaces;
using Newtonsoft.Json;
using ToDoList.DAL.FilePath;
using Newtonsoft.Json.Linq;

namespace ToDoList.DAL.Repositories.Implementations
{
    public class TaskOperations : ITaskOperations
    {
        private FilePath.FilePath _fp = new();
        public IEnumerable<Entities.Task> GetAllTasks()
        {
            var allData = File.ReadAllText(_fp.path);
            List<Entities.Task> taskList = new(); 
            if(allData == null) return taskList;

            taskList = JsonConvert.DeserializeObject<List<Entities.Task>>(allData); 
            return taskList;
        }


        public Entities.Task GetTaskById(int id)
        {
            var allData = File.ReadAllText(_fp.path);
            var taskList = JsonConvert.DeserializeObject<List<Entities.Task>>(allData);

            if(taskList.Count == 0) 
                return new Entities.Task();

            else
                return taskList.Where(t => t.Id == id).FirstOrDefault();
        }

        public int AddNewTask(Entities.Task task)
        {
            if(task.Id < 0 ||  task.Id > int.MaxValue)
            {
                return -1; 
            }

            var allJsonData = File.ReadAllText(_fp.path);

            var taskList = JsonConvert.DeserializeObject<List<Entities.Task>>(allJsonData) ?? new List<Entities.Task>();

            var ifTaskExists = taskList.Where((t) => t.Id == task.Id).FirstOrDefault();
            if (ifTaskExists != null) return -1; 


            taskList.Add(task);
            allJsonData = JsonConvert.SerializeObject(taskList , Formatting.Indented);
            File.WriteAllText(_fp.path, allJsonData);
            return 1; 
        }


        public int DeleteTask(int id)
        {
            if (id < 0 || id > int.MaxValue) return -1; 
            var allJsonData = File.ReadAllText(_fp.path);
            var taskList = JsonConvert.DeserializeObject<List<Entities.Task>>(allJsonData);
            if(taskList.Count == 0) return -1; 

            var taskToRemove = taskList.Where(t => t.Id == id).FirstOrDefault();
            if (taskToRemove == null) return -1; 

            taskList.Remove(taskToRemove);
            allJsonData = JsonConvert.SerializeObject(taskList); 
            File.WriteAllText(_fp.path, allJsonData);
            return 1; 
        }
        

        public int UpdateTask(Entities.Task task)
        {
            var allJsonData = File.ReadAllText(_fp.path);
            var taskList = JsonConvert.DeserializeObject<List<Entities.Task>>(allJsonData);
            if (taskList.Count == 0) return -1; 

            var taskToUpdate = taskList.Where(t => t.Id == task.Id).FirstOrDefault();
            if(taskToUpdate == null) return -1;
            taskList.Remove(taskToUpdate);
            taskList.Add(task); 

            allJsonData = JsonConvert.SerializeObject(taskList);
            File.WriteAllText(_fp.path, allJsonData); 
            return -1; 
        }
    }
}
