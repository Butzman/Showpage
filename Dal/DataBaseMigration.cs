using System;
using System.Linq;
using System.Threading.Tasks;
using Dal.Interfaces.Dal;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dal
{
    public static class DataBaseMigration
    {
        public static async Task EnsureMigrated(IServiceProvider serviceProvider, string dbPath)
        {
            var contextFactory = serviceProvider.GetRequiredService<IContextFactory>();
            var context = contextFactory.CreateContext();

            await Migrate(context, dbPath);
        }
        
        private static async Task Migrate(DalContext context, string dbPath)
        {
            try
            {
                if ((await context.Database.GetPendingMigrationsAsync()).Any())
                    await context.Database.MigrateAsync();
            }
            catch (Exception)
            {
                await TryBackup(context, dbPath);
                await context.Database.EnsureDeletedAsync();
                await context.Database.MigrateAsync();
            }
        }

        private static async Task TryBackup(DalContext context, string dbPath)
        {
            try
            {
                var backupConnection =
                    new SqliteConnection($"Data Source={dbPath}.{DateTime.Now:yyyy-MM-dd--HH-mm-ss}.backup");
                await backupConnection.OpenAsync();
                var dbConnection = ((SqliteConnection) context.Database.GetDbConnection());
                await dbConnection.OpenAsync();
                dbConnection.BackupDatabase(backupConnection);
                backupConnection.Close();
                dbConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}