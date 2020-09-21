using System;
using System.Threading.Tasks;
using Backend_Shared.Interfaces.DataServices;
using Backend_Shared.Models;
using Dal.Services;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace Dal.Test.Products
{
    [TestFixture]
    public class Save : DbServiceTestBase
    {
        private Mock<IProductDataService> _dataServiceMock = new Mock<IProductDataService>();
        private ProductDbService GetDbService()
            => new ProductDbService(_dataServiceMock.Object, ContextFactory, NullLogger<ProductDbService>.Instance, GetMapper());

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
            result.Name.ShouldBe(name);
            result.EAN.ShouldBe(ean);
            _dataServiceMock.Verify(x=>x.HandleAddOrUpdate(It.Is<ProductModel>(x=>x==result)));
        }

        // [Test]
        // public async Task CreatedEntry_GetPublished_OverDataService()
        // {
        //     //Arrange
        //     var dbService = GetDbService();
        //
        //     var id = Guid.NewGuid().ToString();
        //     const string name = "First Product";
        //     var ean = RandomDigits(9);
        //     
        //     var product = new ProductModel
        //     {
        //         Id = id,
        //         Name = name,
        //         EAN = ean
        //     };
        //     
        //     //Act
        //     
        // }
        
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