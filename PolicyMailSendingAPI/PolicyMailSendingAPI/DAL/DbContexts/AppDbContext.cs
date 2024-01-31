using PolicyMailSendingAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore; 
namespace PolicyMailSendingAPI.DAL.DbContexts
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ViewEntity>().HasNoKey().ToView("ViewEntities"); 
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ViewEntity> ViewEntities { get; set; }
    }
}
