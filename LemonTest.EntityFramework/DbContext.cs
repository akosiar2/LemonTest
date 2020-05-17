using Microsoft.EntityFrameworkCore;
using LemonTest.Model;

namespace LemonTest.EntityFramework
{
    public class LemonTestDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public LemonTestDbContext(DbContextOptions<LemonTestDbContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
