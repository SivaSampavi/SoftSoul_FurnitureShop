using Furniture_ShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Furniture_Shop.Data
{
    public class Furniture_ShopAPIDbContext : DbContext
    {
        public Furniture_ShopAPIDbContext(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }


    }
}
