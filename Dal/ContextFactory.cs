using System;
using System.IO;
using Dal.Interfaces.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Dal
{
    public class ContextFactory : IContextFactory, IDesignTimeDbContextFactory<DalContext>
    {
        public ContextFactory()
        {
        }


        public DalContext CreateContext()
            => new DalContext(GetContextOptionsBuilder().Options);

        public DalContext CreateDbContext(string[] args)
            => CreateContext();

        private DbContextOptionsBuilder<DalContext> GetContextOptionsBuilder()
        {
            var environmentVariable = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var filename = "appsettings." + environmentVariable + ".json";
            var settingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(settingsPath)
                .Build();

            var databasePath = environmentVariable == "Production" ? "/data" : Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            var connectionString = "Data Source=" + Path.Combine(databasePath, "Showpage", configuration.GetConnectionString("DataBase"));
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<DalContext>();
            return dbContextOptionsBuilder.UseSqlite(connectionString);
        }
    }
}