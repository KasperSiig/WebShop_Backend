using Microsoft.EntityFrameworkCore;
using WebShop.Core.Entity;

namespace WebShop.Infrastructure.Data
{
    public class WebShopContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}