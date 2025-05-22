using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using OnlineStore.Models.Entities;

namespace OnlineStore.Data
{
    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    //    protected override void OnModelCreating(ModelBuilder builder)
    //    {
    //        base.OnModelCreating(builder);
    //    }
    //}
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions
            <ApplicationDbContext> options):
            base(options) { }

        public DbSet<Product> Products { get; set; } = null;
        public DbSet<Category> Categories { get; set; } = null;
        public DbSet<ProductFeature> ProductFeatures { get; set; } = null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Product entity
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category) // Master Side
                .WithMany(c => c.Products)  // Details Side
                .HasForeignKey(p => p.CategoryId);// FK

            // Configure the Category entity
            modelBuilder.Entity<ProductFeature>()
                .HasOne(pf => pf.Product)
                .WithMany(p => p.Features)
                .HasForeignKey(pf => pf.ProductId);
        }
    }
}
