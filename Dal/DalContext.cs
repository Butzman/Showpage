using System.Linq;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class DalContext : DbContext
    {

        public DalContext()
        {
        }


        public DalContext(DbContextOptions<DalContext> dbContextOptions) : base(dbContextOptions)
        {
        }


        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CartEntity> Carts { get; set; }
        public DbSet<ProductToCartEntity> ProductToCartEntities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DalContext).Assembly);

            AddSeedingData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
        
        protected virtual void AddSeedingData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>()
                .HasData(SeedingData.Products.ToArray());
            modelBuilder.Entity<CartEntity>()
                .HasData(SeedingData.Carts.ToArray());
            modelBuilder.Entity<ProductToCartEntity>()
                .HasData(SeedingData.ProductToCartEntities.ToArray());
        }
    }
}