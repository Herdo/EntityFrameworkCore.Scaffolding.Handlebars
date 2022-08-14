using Microsoft.EntityFrameworkCore;
using Scaffolding.Handlebars.Tests.Models;

namespace Scaffolding.Handlebars.Tests.Contexts
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext() { }

        public NorthwindDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Territory> Territories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasComment("A category of products")
                .Property(category => category.CategoryName)
                    .HasComment("The name of a category");
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerKey).IsFixedLength();
            });

            modelBuilder.Entity<Territory>(entity =>
            {
                entity.Property(e => e.TerritoryId)
                      .HasConversion(valueFromCode => (string)valueFromCode,
                                     valueFromProvider => (TerritoryId)valueFromProvider);
            });
            
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                      .HasConversion(valueFromCode => (int)valueFromCode,
                                     valueFromProvider => (EmployeeId)valueFromProvider);
                
                entity.HasMany(d => d.Territories)
                      .WithMany(p => p.Employees)
                      .UsingEntity("EmployeeTerritory");
            });
        }
    }
}
