using Microsoft.EntityFrameworkCore;
using StoreModels;

namespace StoreDL
{
    public class StoreDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set;}
        public DbSet<LineItem> LineItems { get; set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Location> Locations { get; set; }

        public StoreDBContext() : base() { }
        public StoreDBContext(DbContextOptions options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder p_options)
        //{
        //    p_options.UseSqlServer(@"");
        //}

        protected override void OnModelCreating(ModelBuilder p_modelBuilder)
        {
            p_modelBuilder.Entity<Customer>()
                .Property(cust => cust.CustomerId)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<LineItem>()
                .Property(item => item.LineItemId)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Order>()
                .Property(ord => ord.OrderId)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Product>()
                .Property(prod => prod.ProductId)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Location>()
                .Property(loc => loc.LocationId)
                .ValueGeneratedOnAdd();
        }

    }
}