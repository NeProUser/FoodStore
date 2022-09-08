using Microsoft.EntityFrameworkCore;

namespace FoodStoreApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Category> Category { get; set; }
        public DbSet<Models.Manufacturer> Manufacturer { get; set; }
    }
}
