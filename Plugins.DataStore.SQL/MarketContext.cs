using CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace Plugins.DataStore.SQL
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Beverage", Description = "Beverage" },
                new Category { CategoryId = 2, Name = "Bakery", Description = "Bakery" },
                new Category { CategoryId = 3, Name = "Meat", Description = "Meat" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, CategoryId = 1, Name = "Ice Tea", Quantity = 100, Price = 1.59 },
                new Product { ProductId = 2, CategoryId = 1, Name = "Lipton", Quantity = 200, Price = 2.69 },
                new Product { ProductId = 3, CategoryId = 2, Name = "Harry's", Quantity = 150, Price = 2.99 },
                new Product { ProductId = 4, CategoryId = 2, Name = "White Bread", Quantity = 200, Price = 1.99 },
                new Product { ProductId = 5, CategoryId = 2, Name = "Black Bread", Quantity = 200, Price = 1.99 },
                new Product { ProductId = 6, CategoryId = 3, Name = "Chicken fillet", Quantity = 120, Price = 8.99 }
            );
        }
    }
}