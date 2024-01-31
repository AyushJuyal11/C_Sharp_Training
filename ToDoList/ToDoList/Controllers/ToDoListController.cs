using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoList.DAL.DbContexts;
using ToDoList.DAL.Entities;
using ToDoList.DAL.Repositories.Implementations;
using ToDoList.DAL.Repositories.Interfaces;
using ToDoList.Models.RequestViewModels;
using ToDoList.Models.ResponseViewModels;
using ToDoList.Services.Interfaces;
using ToDoList.ResponseModels; 

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoListController : ControllerBase
    {

        private readonly IToDoService _toDoServices; 
        public ToDoListController(IToDoService toDoServices)
        {
            _toDoServices=toDoServices;
        }

        [HttpGet("get-all-tasks")]
        public async Task<IActionResult> GetAllTasksAsync()
        {
            APIResponse response = new(); 
            try
            {
                IEnumerable<ToDoResponse> allItems = await _toDoServices.GetAllItemsAsync();
                response.Body = allItems;
                return Ok(response);
            }
            catch(Exception e)
            {
                response.Message = e.Message;
                response.Code = "500";
                response.Errors = e.ToString(); 
                return Ok(response); 
            }
        }

        [HttpPost("add-task")]
        public async Task<IActionResult> AddTaskAsync([FromBody] ToDoRequest item)
        {

            APIResponse response = new(); 
            try
            {
                ToDoResponse addedItem = await _toDoServices.AddItemAsync(item);
                response.Body = addedItem; 
                return Ok(response);
            }
            catch(Exception e)
            {
                response.Errors = e.ToString();
                response.Code = "400"; 
                response.Message = e.Message; 
                return Ok(response);
            }
        }

        [HttpGet("get-task")]
        public async Task<ActionResult> GetTaskAsync(int id)
        {
            APIResponse response = new(); 
            try
            {
                ToDoResponse requestedToDoItem = await _toDoServices.GetItemByIdAsync(id);
                response.Body = requestedToDoItem; 
                return Ok(response);
            }
            catch(Exception e)
            {
                response.Errors = e.ToString();
                response.Code = "404"; 
                response.Message = e.Message; 
                return Ok(response);
            }
        }

        [HttpPut("update-task")]
        public async Task<ActionResult> UpdateTaskAsync([FromBody] ToDoRequest item)
        {
            APIResponse response = new(); 
            try
            {
                ToDoResponse updatedToDoItem = await _toDoServices.UpdateItemAsync(item);
                response.Body = updatedToDoItem;
                return Ok(response); 
            }
            catch(Exception e)
            {
                response.Errors = e.ToString();
                response.Code = "404"; 
                response.Message = e.Message; 
                return Ok(response);
            }
        }

        [HttpDelete("delete-task")]
        public async Task<IActionResult> DeleteTaskAsync(int id)
        {
            APIResponse response = new();
            try
            {
                ToDoResponse deletedToDoItem = await _toDoServices.DeleteItemByIdAsync(id);
                response.Body = deletedToDoItem;
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Errors = e.ToString();
                response.Code = "404";
                response.Message = e.Message;
                return Ok(response);
            }
        }
    }
}
