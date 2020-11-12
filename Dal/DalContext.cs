using System;
using System.Linq;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class DalContext : DbContext
    {
        private string _dbConnectionString;
        private DbContextOptions<DalContext> _dbContextOptions;


        public DalContext()
        {
        }

        public DalContext(string dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }

        public DalContext(DbContextOptions<DalContext> dbContextOptions) : base(dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_dbContextOptions == null)
            {
                _dbConnectionString ??= "C:\\Users\\butzh\\AppData\\Local\\CodersShop\\database_api.sqlite";
                Console.WriteLine("Using Database: " + $"Data Source={_dbConnectionString}");
                optionsBuilder.EnableSensitiveDataLogging()
                    .UseSqlite($"Data Source={_dbConnectionString}");
            }

            base.OnConfiguring(optionsBuilder);
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