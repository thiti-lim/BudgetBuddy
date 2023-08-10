using BudgetBuddy.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Customer> Customers => Set<Customer>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = Guid.NewGuid(), Name = "Test 1" },
                new Customer { Id = Guid.NewGuid(), Name = "Test 2" },
                new Customer { Id = Guid.NewGuid(), Name = "Test 3" }
            );
        }
    }
}
