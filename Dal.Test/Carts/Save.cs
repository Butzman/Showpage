using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_Shared.Interfaces.DataServices;
using Backend_Shared.Interfaces.DbServices;
using Backend_Shared.Models;
using Dal.Services;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace Dal.Test.Carts
{
    [TestFixture]
    public class Save: DbServiceTestBase
    {
        private Mock<ICartDataService> _dataServiceMock = new Mock<ICartDataService>();
        private ICartDbService GetDbService()
            => new CartDbService(_dataServiceMock.Object, ContextFactory, NullLogger<CartDbService>.Instance, GetMapper());

        [Test]
        public async Task Create_NewEntryShouldBeSavedCorrectly()
        {
            //Arrange
            var dbService = GetDbService();

            var cartModel = new CartModel
            {
                Id = "Cart_1",
                Name = "Name",
                UserId = Guid.NewGuid().ToString(),
                Products = new List<ProductToCartModel>
                {
                    new ProductToCartModel {ProductId = "4b760d44-10eb-4596-9d6f-da12e4e9a228", Amount = 2},
                    new ProductToCartModel {ProductId = "4b760d45-10eb-4596-9d6f-da12e4e9a228", Amount = 3},
                    new ProductToCartModel {ProductId = "4b760d46-10eb-4596-9d6f-da12e4e9a228", Amount = 4},
                    new ProductToCartModel {ProductId = "4b760d47-10eb-4596-9d6f-da12e4e9a228", Amount = 5},
                }
            };
            
            //Act
            var result = await dbService.Save(cartModel);
            
            //Assert
            result.Id.ShouldBe(cartModel.Id);
            result.Name.ShouldBe(cartModel.Name);
            result.Products.First(x=>x.ProductId.Equals("4b760d44-10eb-4596-9d6f-da12e4e9a228")).Amount.ShouldBe(2);
            _dataServiceMock.Verify(x=>x.HandleAddOrUpdate(It.Is<CartModel>(model=>model==result)));
        }
    }
}