using Dal.Interfaces.Dal;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Dal.Test
{
    public class TestContextFactory: IContextFactory {
        private DbContextOptions<DalContext> _dbContextOptions;

        public DalContext CreateContext()
            => new DalContext(_dbContextOptions);

        public void UseConnection(SqliteConnection sqliteConnection)
            => _dbContextOptions = new DbContextOptionsBuilder<DalContext>()
                .UseSqlite(sqliteConnection)
                .Options;

        DalContext IContextFactory.CreateContext()
            => CreateContext();
    }
}