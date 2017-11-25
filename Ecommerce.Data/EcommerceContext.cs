using Ecommerce.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");

            modelBuilder.Entity<Category>().Property(u => u.Name).HasMaxLength(250).IsRequired();

            modelBuilder.Entity<Category>().Property(u => u.Sequence).HasMaxLength(10).IsRequired();

            modelBuilder.Entity<Product>().ToTable("Product");

            modelBuilder.Entity<Product>().Property(u => u.Name).HasMaxLength(250).IsRequired();

            modelBuilder.Entity<Product>().Property(u => u.CategoryId).IsRequired();

            modelBuilder.Entity<Product>().Property(u => u.Color).IsRequired();

            modelBuilder.Entity<Product>().Property(u => u.Description).IsRequired();

            modelBuilder.Entity<Product>().Property(u => u.Size).IsRequired();

            modelBuilder.Entity<Product>().HasOne(a => a.Categories).WithMany(u => u.Products)
                .HasForeignKey(a => a.CategoryId);
        }
    }
}