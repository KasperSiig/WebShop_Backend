using System.IO.Compression;
using Microsoft.EntityFrameworkCore;
using WebShop.Core.Entity;

namespace WebShop.Infrastructure.Data
{
    public class WebShopContext : DbContext
    {
        protected WebShopContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Chair> Chairs { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Designer> Designers { get; set; }
        public DbSet<Maker> Makers { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}