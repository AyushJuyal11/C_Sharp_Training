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

        private ToDoListOperations _task = new();

        [HttpGet("get-all-tasks")]
        public async Task<IActionResult> GetAllTasksAsync()
        {
            var tasks = await _task.GettingAllTasksAsync();
            if (tasks == null) return NotFound();
            else return Ok(tasks);
        }

        [HttpPost("add-task")]
        public async Task<IActionResult> AddTaskAsync([FromBody] ToDoItem item)
        {
            int result = await _task.AddNewTaskAsync(item);
            if (result <= 0) return BadRequest();
            else return Ok("task created with task id = " + item.Id); 
        }

        [HttpGet("get-task")]
        public async Task<IActionResult> GetTaskAsync(int id)
        {
            var t = await _task.GetTaskByIdAsync(id);
            if(t == null) return NotFound();
            return Ok(t);
        }

        [HttpPut("update-task")]
        public async Task<IActionResult> UpdateTaskAsync([FromBody]ToDoItem item)
        {
            var result = await _task.UpdatingTaskAsync(item);
            if (result < 0) return BadRequest();
            else return Ok($"task updated with task id {item.Id}"); 
        }

        [HttpDelete("delete-task")]
        public async Task<IActionResult> DeleteTaskAsync(int id)
        {
            var result = await _task.DeletingTaskAsync(id);
            if(result <= 0) return NotFound();
            return Ok("task deleted");
        }
    }
}
