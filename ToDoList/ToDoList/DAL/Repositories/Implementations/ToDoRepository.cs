using Microsoft.EntityFrameworkCore;
using ToDoList.DAL.DbContexts;
using ToDoList.DAL.Entities;
using ToDoList.DAL.Repositories.Interfaces;
using ToDoList.Models.RequestViewModels;

namespace ToDoList.DAL.Repositories.Implementations
{
    public class ToDoRepository : IToDoRepository
    {
        private ToDoApplicationContext _context; 
        public ToDoRepository(ToDoApplicationContext context)
        {
            _context=context;
        }

        public async Task<ToDoEntity> AddNewTaskAsync(ToDoEntity item)
        {
            _context.Add(item); 
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<ToDoEntity> DeletingTaskAsync(int id)
        {
            ToDoEntity? item = await _context.ToDoItems.FindAsync(id);
            _context.Remove(item);
            _context.SaveChanges();
            return item; 
            
        }

        public async Task<ToDoEntity> GetTaskByIdAsync(int id)
        {
            ToDoEntity? requiredItem = await _context.ToDoItems.FindAsync(id); 
            return requiredItem;
        }

        public async Task<IEnumerable<ToDoEntity>> GettingAllTasksAsync()
        {
            List<ToDoEntity> allToDoItems =  await _context.ToDoItems.ToListAsync();
            return allToDoItems;
        }

        public async Task<ToDoEntity> UpdatingTaskAsync(ToDoEntity item)
        {
            ToDoEntity? updatedItem = await _context.ToDoItems.FindAsync(item.Id); 
            updatedItem.Description = item.Description;
            updatedItem.Id = item.Id;
            updatedItem.Name = item.Name;
            await _context.SaveChangesAsync();
            return updatedItem; 
        }
    }
}
