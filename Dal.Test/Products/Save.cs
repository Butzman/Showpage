using System;
using System.Threading.Tasks;
using Dal.Services;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using Shared.Models;
using Shared.Services.DataServices;
using Shouldly;

namespace Dal.Test.Products
{
    [TestFixture]
    public class Save : DbServiceTestBase
    {
        private ProductDataService GetDataService()
            => new ProductDataService();

        private ProductDbService GetDbService()
            => new ProductDbService(GetDataService(), ContextFactory, NullLogger<ProductDbService>.Instance, GetMapper());

        [Test]
        public async Task Create_NewEntryShouldBeSavedCorrectly()
        {
            //Arrange
            var dbService = GetDbService();

            var id = Guid.NewGuid().ToString();
            const string name = "First Product";
            var ean = RandomDigits(9);
            
            var product = new ProductModel
            {
                Id = id,
                Name = name,
                EAN = ean
            };
            
            //Act
            var result = await dbService.Save(product);
            
            //Assert
            result.Id.ShouldBe(id);
            result.Id.ShouldNotBe(null);
            result.Name.ShouldBe(name);
            result.Name.ShouldNotBe(null);
            result.EAN.ShouldBe(ean);
            result.EAN.ShouldNotBe(null);
        }

        private static string RandomDigits(int length)
        {
            var random = new Random();
            var s = string.Empty;
            for (var i = 0; i < length; i++)
                s = string.Concat(s, random.Next(10).ToString());
            return s;
        }
    }
}