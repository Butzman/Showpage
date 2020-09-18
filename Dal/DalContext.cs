using System.Linq;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class DalContext : DbContext
    {
        private readonly string _dbConnectionString;
        private DbContextOptions<DalContext> _dbContextOptions;


        public DalContext() : this("C:\\Users\\butzh\\AppData\\Local\\CodersShop\\database_api.sqlite")
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ProductEntity.ConfigureEntity(modelBuilder);
            CartEntity.ConfigureEntity(modelBuilder);

            AddSeedingData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_dbContextOptions == null)
                optionsBuilder.EnableSensitiveDataLogging()
                    .UseSqlite($"Data Source={_dbConnectionString}");

            base.OnConfiguring(optionsBuilder);
        }

        protected virtual void AddSeedingData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>()
                .HasData(SeedingData.Products.ToArray());
        }
    }
}