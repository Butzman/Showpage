using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class DalContext : DbContext
    {
        private readonly string _dbConnectionString;


        public DalContext(): this("C:\\Users\\butzh\\AppData\\Local\\CodersShop\\database_api.sqlite") 
        {
        }
        public DalContext(string dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }

        public DalContext(DbContextOptions<DalContext> dbContextOptions) : base(dbContextOptions){}


        public DbSet<ProductEntity> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ProductEntity.ConfigureEntity(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging()
                .UseSqlite($"Data Source={_dbConnectionString}");
        
            base.OnConfiguring(optionsBuilder);
        }
    }
}