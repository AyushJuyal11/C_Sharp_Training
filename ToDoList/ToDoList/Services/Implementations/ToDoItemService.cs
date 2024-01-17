using AutoMapper;
using ToDoList.DAL.Entities;
using ToDoList.DAL.Repositories.Interfaces;
using ToDoList.Models.RequestViewModels;
using ToDoList.Models.ResponseViewModels;
using ToDoList.Services.Interfaces;

namespace ToDoList.Services.Implementations
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoListOperations _operations;
        private readonly IMapper _mapper; 

        public ToDoItemService(IToDoListOperations operations, IMapper mapper)
        {
            this._operations=operations;
            this._mapper=mapper;
        }

        public async Task<ToDoItemResponse> AddItemAsync(ToDoItemRequest requestItem)
        {
            var toDoItem = _mapper.Map<ToDoItem>(requestItem);
            var Item = await _operations.AddNewTaskAsync(toDoItem);
            if (Item != null)
            {
                var addedItem = _mapper.Map<ToDoItemResponse>(Item);
                return addedItem;
            }
            else return new ToDoItemResponse(); 
        }

        public async Task<ToDoItemResponse> DeleteItemByIdAsync(int id)
        {
            var deletedItem = await _operations.DeletingTaskAsync(id);
            if (deletedItem != null)
            {
                var deletedResponse = _mapper.Map<ToDoItemResponse>(deletedItem);
                return deletedResponse;
            }
            else return new ToDoItemResponse(); 
        }

        public async Task<IEnumerable<ToDoItemResponse>> GetAllItemsAsync()
        {

            var allItems = await _operations.GettingAllTasksAsync();
            if (allItems == null) return new List<ToDoItemResponse>();

            var response = _mapper.Map<IEnumerable<ToDoItemResponse>>(allItems);
            return response; 
        }

        public async Task<ToDoItemResponse> GetItemByIdAsync(int id)
        {
            var item = await _operations.GetTaskByIdAsync(id);
            if(item == null) return new ToDoItemResponse();
            else
            {
               var response = _mapper.Map<ToDoItemResponse>(item);
                return response; 
            }
        }

        public async Task<ToDoItemResponse> UpdateItemAsync(ToDoItemRequest item)
        {
            var Item = _mapper.Map<ToDoItem>(item); 
            var updatedItem = await _operations.UpdatingTaskAsync(Item);
            if (updatedItem == null) return new ToDoItemResponse();
            else
            {
                var toDoResponse = _mapper.Map<ToDoItemResponse>(updatedItem);
                return toDoResponse;
            }
        }
    }
}
