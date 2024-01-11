using Microsoft.AspNetCore.Mvc;
using ToDoList.DAL.Entities;
using ToDoList.DAL.Repositories.Implementations;
using ToDoList.DAL.Repositories.Interfaces;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoListController : ControllerBase
    {

        private TaskOperations _task = new();

        [HttpGet("get-all-tasks")]
        public IActionResult Index()
        {
            var tasks = _task.GetAllTasks();
            if (tasks == null) return NotFound();
            else return Ok(tasks);
        }

        [HttpPost("add-new-item")]
        public IActionResult Post([FromBody] DAL.Entities.Task task)
        {
            int result = _task.AddNewTask(task);
            if (result <= 0) return BadRequest();
            else return Ok("task created with task id = " + task.Id); 
        }

        [HttpGet("get-task-by-id")]
        public IActionResult Get(int id)
        {

            var t = _task.GetTaskById(id);
            if(t == null) return NotFound();
            return Ok(t);

        }

        [HttpPut("update-task")]
        public IActionResult Put([FromBody]DAL.Entities.Task task)
        {
            var result = _task.UpdateTask(task);
            if (result <= 0) return BadRequest();
            else return Ok("task updated"); 
        }

        [HttpDelete("delete-list-item")]
        public IActionResult Delete(int id)
        {
            var result = _task.DeleteTask(id);
            if(result <= 0) return NotFound();
            return Ok("task deleted");
        }
    }
}
