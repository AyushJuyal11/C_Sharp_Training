using Microsoft.EntityFrameworkCore;
using ToDoList.DAL.Entities;

namespace ToDoList.DAL.DbContexts
{
    public class ToDoApplicationContext : DbContext
    {
        public ToDoApplicationContext(DbContextOptions options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
