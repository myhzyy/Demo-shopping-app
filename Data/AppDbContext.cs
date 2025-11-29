using Microsoft.EntityFrameworkCore;


public class AppDbContext : DbContext
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers {get;set;}
    public DbSet<Order> Orders {get;set;}
    public DbSet<OrderLineItem> OrderLineitems {get;set;}
    public DbSet<Product> Products {get;set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        /// Precision - 
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(10, 2);


        /// Seeding data -
        modelBuilder.Entity<Product>().HasData(
        new Product {
        Id = 1,
        ProductName = "T-Shirt",
        Description = "Classic oversized washed tee.",
        Price = 15.00m,
        ImageUrl = "https://images.unsplash.com/photo-1521572163474-6864f9cf17ab"
        },
        new Product {
        Id = 2,
        ProductName = "Leg Warmers",
        Description = "Knitted retro leg warmers.",
        Price = 10.00m,
        ImageUrl = "https://images.unsplash.com/photo-1503342217505-b0a15ec3261c"
        },
        new Product {
        Id = 3,
        ProductName = "Carhart Jacket",
        Description = "Heavy-duty lined winter jacket.",
        Price = 200.00m,
        ImageUrl = "https://images.unsplash.com/photo-1523381294911-8d3cead13475"
    }
);


        modelBuilder.Entity<Customer>().HasData(
        new Customer {Id = 1, CustomerName = "Jordan Lawrence"},
        new Customer {Id = 2, CustomerName = "Hayley Ryan"}
        );

        modelBuilder.Entity<Order>().HasData(
        new Order {Id = 1, CustomerId = 1, OrderDate = DateTime.UtcNow},
        new Order {Id = 2, CustomerId = 2, OrderDate = DateTime.UtcNow}
        );

        modelBuilder.Entity<OrderLineItem>().HasData(
        new OrderLineItem {Id = 1, OrderId = 1, ProductId = 1, Quantity = 1},
        new OrderLineItem {Id = 2, OrderId = 2, ProductId = 3, Quantity = 1},
        new OrderLineItem {Id = 3, OrderId = 2, ProductId = 2, Quantity = 2}
        );

        base.OnModelCreating(modelBuilder);
    }

}