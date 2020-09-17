using Dal.Interfaces.Dal;
using Microsoft.EntityFrameworkCore.Design;

namespace Dal
{
    public class ContextFactory : IContextFactory, IDesignTimeDbContextFactory<DalContext>
    {
        private readonly string _dbConnectionString;

        public ContextFactory(string dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }

        public DalContext CreateContext()
            => new DalContext(_dbConnectionString);

        public DalContext CreateDbContext(string[] args)
            => CreateContext();
    }
}