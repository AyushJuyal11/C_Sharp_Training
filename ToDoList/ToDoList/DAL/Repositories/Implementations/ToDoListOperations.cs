using Microsoft.EntityFrameworkCore;
using ToDoList.DAL.DbContexts;
using ToDoList.DAL.Entities;
using ToDoList.DAL.Repositories.Interfaces;
using ToDoList.Models.RequestViewModels;

namespace ToDoList.DAL.Repositories.Implementations
{
    public class ToDoListOperations : IToDoListOperations
    {
        private ToDoApplicationContext _context; 
        public ToDoListOperations(ToDoApplicationContext context)
        {
            _context=context;
        }

        public async Task<ToDoItem> AddNewTaskAsync(ToDoItem item)
        {
            _context.Add(item); 
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<ToDoItem> DeletingTaskAsync(int id)
        {
            var item = await _context.ToDoItems.FindAsync(id);
            if (item == null)
            {
                return new ToDoItem(); 
            }

            else
            {
                _context.Remove(item);
                _context.SaveChanges();
                return item; 
            }
        }

        public async Task<ToDoItem> GetTaskByIdAsync(int id)
        {
            var requiredItem = await _context.ToDoItems.FindAsync(id); 
            if(requiredItem == null)
            {
                return new ToDoItem();
            }
            return requiredItem;
        }

        public async Task<IEnumerable<ToDoItem>> GettingAllTasksAsync()
        {
            var allItems =  await _context.ToDoItems.ToListAsync();
            if (allItems.Count != 0)
            {
                return allItems;
            }
            else return new List<ToDoItem>();
        }

        public async Task<ToDoItem> UpdatingTaskAsync(ToDoItem item)
        {
            var updatedItem = await _context.ToDoItems.FindAsync(item.Id); 
            if(updatedItem == null)
            {
                return new ToDoItem();
            }
            updatedItem.Description = item.Description;
            updatedItem.Id = item.Id;
            updatedItem.Name = item.Name;
            await _context.SaveChangesAsync();
            return updatedItem; 
        }
    }
}
