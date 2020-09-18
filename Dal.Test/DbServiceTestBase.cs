using AutoMapper;
using Microsoft.Data.Sqlite;
using NUnit.Framework;

namespace Dal.Test
{
    public class DbServiceTestBase
    {
        private SqliteConnection _sqliteConnection;
        protected readonly TestContextFactory ContextFactory = new TestContextFactory();
        
        [SetUp]
        public void Setup()
        {
            _sqliteConnection.Open();
            ContextFactory.UseConnection(_sqliteConnection);
            
            CreateSchemaInDatabase();
        }
        
        [OneTimeSetUp]
        public void CreateDatabaseConnection()
            => _sqliteConnection = new SqliteConnection("DataSource=:memory:");
        
        [TearDown]
        public void DropDatabase()
            => _sqliteConnection.Close();

        private void CreateSchemaInDatabase()
        {
            using var context = ContextFactory.CreateContext();
            context.Database.EnsureCreated();
        }

        protected static IMapper GetMapper()
        {
            var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<Dal.AutomapperProfile>(); });
            var mapper = configuration.CreateMapper();
            return mapper;
        }
    }
}