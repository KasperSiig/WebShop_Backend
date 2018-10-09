using System.IO.Compression;
using Microsoft.EntityFrameworkCore;
using WebShop.Core.Entity;
using WebShop.Core.Entity.Relations;

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
<<<<<<< HEAD
=======
        public DbSet<Category> Categories { get; set; }
>>>>>>> fluentapi
        public DbSet<Color> Colors { get; set; }
        public DbSet<Designer> Designers { get; set; }
        public DbSet<Maker> Makers { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ChairCategory

            modelBuilder.Entity<ChairCategory>()
                .HasKey(t => new {t.ChairId, t.CategoryId});

            modelBuilder.Entity<ChairCategory>()
                .HasOne(cc => cc.Chair)
                .WithMany(c => c.ChairCategories)
                .HasForeignKey(cc => cc.ChairId);

            modelBuilder.Entity<ChairCategory>()
                .HasOne(cc => cc.Category)
                .WithMany(c => c.ChairCategories)
                .HasForeignKey(cc => cc.CategoryId);

            #endregion

            #region ChairColor

            modelBuilder.Entity<ChairColor>()
                .HasKey(t => new {t.ChairId, t.ColorId});

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
                .HasKey(t => new {t.ChairId, t.TagId});

            modelBuilder.Entity<ChairTag>()
                .HasOne(ct => ct.Chair)
                .WithMany(c => c.ChairTags)
                .HasForeignKey(ct => ct.ChairId);

            modelBuilder.Entity<ChairTag>()
                .HasOne(ct => ct.Tag)
                .WithMany(t => t.ChairTags)
                .HasForeignKey(ct => ct.TagId);

            #endregion
        }
    }
}