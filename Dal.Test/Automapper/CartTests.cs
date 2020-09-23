using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Backend_Shared.Models;
using Dal.Entities;
using NUnit.Framework;
using Shouldly;

namespace Dal.Test.Automapper
{
    [TestFixture]
    public class CartTests
    {
        [Test]
        public void CartModel_To_CartEntity()
        {
            //Arrange
            var cartModel = new CartModel
            {
                Id = "Cart_1",
                Name = "Name",
                UserId = Guid.NewGuid().ToString(),
                Products = new List<ProductToCartModel>
                {
                    new ProductToCartModel {ProductId = "Pro_1", Amount = 2},
                    new ProductToCartModel {ProductId = "Pro_2", Amount = 3},
                    new ProductToCartModel {ProductId = "Pro_3", Amount = 4},
                    new ProductToCartModel {ProductId = "Pro_4", Amount = 5},
                }
            };
            var mapper = GetMapper();

            //Act
            var cartEntity = mapper.Map<CartEntity>(cartModel);
            
            //Assert
            cartEntity.Id.ShouldBe(cartModel.Id);
            cartEntity.Name.ShouldBe(cartModel.Name);
            cartEntity.UserId.ShouldBe(cartModel.UserId);
            cartEntity.Products.First(x=>x.ProductId.Equals("Pro_3")).Amount.ShouldBe(4);
        }


        private static IMapper GetMapper()
        {
            var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<Dal.AutomapperProfile>(); });
            var mapper = configuration.CreateMapper();
            return mapper;
        }
    }
}