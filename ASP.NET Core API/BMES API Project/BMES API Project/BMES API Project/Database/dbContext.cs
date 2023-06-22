using BMES_API_Project.Models.Address;
using BMES_API_Project.Models.Cart;
using BMES_API_Project.Models.Customer;
using BMES_API_Project.Models.Order;
using BMES_API_Project.Models.Product;
using BMES_API_Project.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace BMES_API_Project.Database
{
    public class dbContext: DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
