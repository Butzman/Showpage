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
    public class Save : DbServiceTestBase
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
                Id = "c_new_1",
                Name = "Name",
                UserId = Guid.NewGuid().ToString(),
                Products = new List<ProductToCartModel>
                {
                    new ProductToCartModel {ProductId = "p1", Amount = 2},
                    new ProductToCartModel {ProductId = "p2", Amount = 3},
                    new ProductToCartModel {ProductId = "p3", Amount = 4},
                    new ProductToCartModel {ProductId = "p4", Amount = 5},
                }
            };

            //Act
            var result = await dbService.Save(cartModel);

            //Assert
            result.Id.ShouldBe(cartModel.Id);
            result.Name.ShouldBe(cartModel.Name);
            result.Products.First(x => x.ProductId.Equals("p1")).Amount.ShouldBe(2);
            _dataServiceMock.Verify(x => x.HandleAddOrUpdate(It.Is<CartModel>(model => model == result)));
        }

        [Test]
        public async Task Updated_EntryShouldBeSavedCorrectly()
        {
            //Arrange
            var dbService = GetDbService();
            var newProducts = new List<ProductToCartModel>
            {
                new ProductToCartModel {ProductId = "p1", Amount = 1},
                new ProductToCartModel {ProductId = "p2", Amount = 2},
                new ProductToCartModel {ProductId = "p3", Amount = 3},
                new ProductToCartModel {ProductId = "p4", Amount = 4},
            };
            var cartModel = new CartModel
            {
                Id = "c_new_1",
                Name = "Name",
                UserId = Guid.NewGuid().ToString(),
                Products = new List<ProductToCartModel>
                {
                    new ProductToCartModel {ProductId = "p1", Amount = 2},
                    new ProductToCartModel {ProductId = "p2", Amount = 3},
                    new ProductToCartModel {ProductId = "p3", Amount = 4},
                    new ProductToCartModel {ProductId = "p4", Amount = 5},
                }
            };

            //Act
            await dbService.Save(cartModel);
            cartModel.Products = newProducts;
            var result = await dbService.Save(cartModel);


            //Assert
            result.Id.ShouldBe(cartModel.Id);
            result.Name.ShouldBe(cartModel.Name);
            result.Products.First(x => x.ProductId.Equals("p1")).Amount.ShouldBe(1);
            _dataServiceMock.Verify(x => x.HandleAddOrUpdate(It.Is<CartModel>(model => model == result)));
        }
    }
}