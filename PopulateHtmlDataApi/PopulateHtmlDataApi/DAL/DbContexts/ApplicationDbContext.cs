using Microsoft.EntityFrameworkCore;
using PopulateHtmlDataApi.DAL.Entities;

namespace PopulateHtmlDataApi.DAL.DbContexts
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<HtmlTemplateEntity> HtmlTemplates { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<DocumentEntity> Documents { get; set; }
    }
}
