using AutoMapper;
using ToDoList.DAL.Entities;
using ToDoList.DAL.Repositories.Interfaces;
using ToDoList.Models.RequestViewModels;
using ToDoList.Models.ResponseViewModels;
using ToDoList.Services.Interfaces;


namespace ToDoList.Services.Implementations
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _operations;
        private readonly IMapper _mapper; 

        public ToDoService(IToDoRepository operations, IMapper mapper)
        {
            this._operations=operations;
            this._mapper=mapper;
        }

        public async Task<ToDoResponse> AddItemAsync(ToDoRequest itemToAdd)
        {
            ToDoEntity? toDoItem = _mapper.Map<ToDoEntity>(itemToAdd);
            ToDoEntity? Item = await _operations.AddNewTaskAsync(toDoItem);
            if (Item != null)
            {
                ToDoResponse addedItem = _mapper.Map<ToDoResponse>(Item);
                return addedItem;
            }
            else return new ToDoResponse(); 
        }

        public async Task<ToDoResponse> DeleteItemByIdAsync(int id)
        {
            ToDoEntity? deletedItem = await _operations.DeletingTaskAsync(id);
            if (deletedItem != null)
            {
                ToDoResponse deletedResponse = _mapper.Map<ToDoResponse>(deletedItem);
                return deletedResponse;
            }
            else throw new Exception("Item not found"); 
        }

        public async Task<IEnumerable<ToDoResponse>> GetAllItemsAsync()
        {

            List<ToDoEntity> allToDoItems = (List<ToDoEntity>)await _operations.GettingAllTasksAsync();
            if (allToDoItems == null) throw new Exception("the list is empty"); 

            List<ToDoResponse> toDoResponse = (List<ToDoResponse>)_mapper.Map<IEnumerable<ToDoResponse>>(allToDoItems);
            return toDoResponse; 
        }

        public async Task<ToDoResponse> GetItemByIdAsync(int id)
        {
            ToDoEntity? requiredItem = await _operations.GetTaskByIdAsync(id);
            if (requiredItem == null) throw new Exception("item not found");
            else
            {
                ToDoResponse toDoResponseItem = _mapper.Map<ToDoResponse>(requiredItem);
                return toDoResponseItem;
            }
        }

        public async Task<ToDoResponse> UpdateItemAsync(ToDoRequest itemToUpdate) 
        {
            ToDoEntity? Item = _mapper.Map<ToDoEntity>(itemToUpdate); 
            ToDoEntity? updatedItem = await _operations.UpdatingTaskAsync(Item);
            if (updatedItem == null) throw new Exception("item not found"); 

            else
            {
                ToDoResponse toDoResponseItem = _mapper.Map<ToDoResponse>(updatedItem);
                return toDoResponseItem;
            }
        }
    }
}
