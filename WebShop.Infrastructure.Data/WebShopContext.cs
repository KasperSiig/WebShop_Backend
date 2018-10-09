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
        public DbSet<Order> Orders { get; set; }

    }
}