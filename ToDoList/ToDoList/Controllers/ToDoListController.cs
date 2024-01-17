using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoList.DAL.DbContexts;
using ToDoList.DAL.Entities;
using ToDoList.DAL.Repositories.Implementations;
using ToDoList.DAL.Repositories.Interfaces;
using ToDoList.Models.RequestViewModels;
using ToDoList.Models.ResponseViewModels;
using ToDoList.Services.Interfaces;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoListController : ControllerBase
    {

        private readonly IToDoItemService _services; 
        public ToDoListController(IToDoItemService services)
        {
            _services=services;
        }

        [HttpGet("get-all-tasks")]
        public async Task<ActionResult<IEnumerable<ToDoItemResponse>>> GetAllTasksAsync()
        {
            var allItems = await _services.GetAllItemsAsync();
            if (allItems == null) return NotFound(); 
            else return Ok(allItems);
        }

        [HttpPost("add-task")]
        public async Task<ActionResult> AddTaskAsync([FromBody] ToDoItemRequest item)
        {
            var newItem = await _services.AddItemAsync(item);
            if (newItem == null) return BadRequest(); 
            return Ok($"Item with id : {item.ID} created"); 
        }

        [HttpGet("get-task")]
        public async Task<ActionResult> GetTaskAsync(int id)
        {
            var requestedItem = await _services.GetItemByIdAsync(id);
            if (requestedItem != null)
            {
                return Ok(requestedItem);
            }
            else return NotFound(); 
        }

        [HttpPut("update-task")]
        public async Task<ActionResult> UpdateTaskAsync([FromBody] ToDoItemRequest item)
        {
            var updatedItem = await _services.UpdateItemAsync(item);
            if (updatedItem != null)
            {
                return Ok($"task updated with id {updatedItem.Id}"); 
            }
            else return NotFound();
        }

        [HttpDelete("delete-task")]
        public async Task<ActionResult> DeleteTaskAsync(int id)
        {
            var deletedItem = await _services.DeleteItemByIdAsync(id);
            if (deletedItem != null)
            {
                return Ok("Item deleted");
            }
            else return NotFound(); 
        }
    }
}
