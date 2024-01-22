using Microsoft.EntityFrameworkCore;
using SoapConfigAPI.DAL.Entities;

namespace SoapConfigAPI.DAL.DbContexts
{
    public class SoapConfigDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<SoapConfig> SoapConfigs { get; set; }

    }
}
