using System.IO.Compression;
using Microsoft.EntityFrameworkCore;
using WebShop.Core.Entity;
using WebShop.Core.Entity.Relations;

namespace WebShop.Infrastructure.Data
{
    public class WebShopContext : DbContext
    {
        public WebShopContext(DbContextOptions options) : base(options)
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


            #region ChairColor

            modelBuilder.Entity<ChairColor>()
                .HasKey(t => new { t.ChairId, t.ColorId });

            modelBuilder.Entity<ChairColor>()
                .HasOne(cc => cc.Chair)
                .WithMany(c => c.ChairColors)
                .HasForeignKey(cc => cc.ChairId);

            modelBuilder.Entity<ChairColor>()
                .HasOne(cc => cc.Color)
                .WithMany(c => c.ChairColors)
                .HasForeignKey(cc => cc.ColorId);

            #endregion

            #region ChairTag

            modelBuilder.Entity<ChairTag>()
                .HasKey(t => new { t.ChairId, t.TagId });

            modelBuilder.Entity<ChairTag>()
                .HasOne(ct => ct.Chair)
                .WithMany(c => c.ChairTags)
                .HasForeignKey(ct => ct.ChairId);

            modelBuilder.Entity<ChairTag>()
                .HasOne(ct => ct.Tag)
                .WithMany(t => t.ChairTags)
                .HasForeignKey(ct => ct.TagId);

            #endregion

            #region User
            modelBuilder.Entity<Customer>()
                        .HasOne(u => u.User)
                        .WithOne(c => c.Customer)
                        .HasForeignKey<User>(u => u.Id);

            modelBuilder.Entity<Employee>()
                        .HasOne(s => s.User)
                        .WithOne(s => s.Employee)
                        .HasForeignKey<User>(u => u.Id);
            #endregion
        }
    }
}