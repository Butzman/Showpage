using System;
using System.Collections.Generic;
using Dal.Entities;

namespace Dal
{
    public static class SeedingData
    {
        public static readonly IList<CartEntity> Carts = new List<CartEntity>
        {
            new CartEntity
            {
                Id = "c1",
                Name = "First Cart",
                UserId = "a7b420a1-66cc-42b3-8bc0-5bc3abf39850"
            },
            new CartEntity
            {
                Id = "c2",
                Name = "Second Cart",
                UserId = "a7b420a1-66cc-42b3-8bc0-5bc3abf39850"
            }
        };

        public static readonly IList<ProductToCartEntity> ProductToCartEntities = new List<ProductToCartEntity>
        {
            new ProductToCartEntity {ProductId = "p1", CartId = "c1", Amount = 2},
            new ProductToCartEntity {ProductId = "p2", CartId = "c1", Amount = 2},
            new ProductToCartEntity {ProductId = "p3", CartId = "c1", Amount = 4},
            new ProductToCartEntity {ProductId = "p4", CartId = "c1", Amount = 2},
            new ProductToCartEntity {ProductId = "p5", CartId = "c1", Amount = 4},
            new ProductToCartEntity {ProductId = "p6", CartId = "c1", Amount = 5},
            new ProductToCartEntity {ProductId = "p1", CartId = "c2", Amount = 6},
            new ProductToCartEntity {ProductId = "p2", CartId = "c2", Amount = 1},
            new ProductToCartEntity {ProductId = "p3", CartId = "c2", Amount = 4},
            new ProductToCartEntity {ProductId = "p4", CartId = "c2", Amount = 3}
        };


        public static readonly IList<ProductEntity> Products = new List<ProductEntity>
        {
            new ProductEntity {Id = "p1", Name = "Vr Glasses", EAN = RandomDigits(9), Description = "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum."},
            new ProductEntity {Id = "p2", Name = "Keyboard", EAN = RandomDigits(9), Description = "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum."},
            new ProductEntity {Id = "p3", Name = "Monitor", EAN = RandomDigits(9), Description = "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum."},
            new ProductEntity {Id = "p4", Name = "Ventilator", EAN = RandomDigits(9), Description = "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum."},
            new ProductEntity {Id = "p5", Name = "Charger", EAN = RandomDigits(9), Description = "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum."},
            new ProductEntity {Id = "p6", Name = "Cup", EAN = RandomDigits(9), Description = "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum."},
        };

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