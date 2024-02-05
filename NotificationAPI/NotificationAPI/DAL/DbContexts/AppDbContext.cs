using NotificationAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore; 
namespace NotificationAPI.DAL.DbContexts
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SendNotificationToDo>().HasNoKey().ToView("SendNotificationToDos"); 
        }
        public DbSet<User> Users { get; set; }
        public DbSet<SendNotificationToDo> SendNotificationToDos { get; set; }
    }
}
