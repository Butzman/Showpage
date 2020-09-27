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
                Id = "4b760d44-10eb-4596-9d6f-da45e4e9a228",
                Name = "First Cart",
                UserId = "a7b420a1-66cc-42b3-8bc0-5bc3abf39850"
            },
            new CartEntity
            {
                Id = "1b760d44-10eb-4596-9d6f-da45e4e9a228",
                Name = "Second Cart",
                UserId = "a7b420a1-66cc-42b3-8bc0-5bc3abf39850"
            }
        };

        public static readonly IList<ProductToCartEntity> ProductToCartEntities = new List<ProductToCartEntity>
        {
            new ProductToCartEntity {ProductId = "4b760d44-10eb-4596-9d6f-da12e4e9a228", CartId = "1b760d44-10eb-4596-9d6f-da45e4e9a228", Amount = 2},
            new ProductToCartEntity {ProductId = "4b760d45-10eb-4596-9d6f-da12e4e9a228", CartId = "1b760d44-10eb-4596-9d6f-da45e4e9a228", Amount = 2},
            new ProductToCartEntity {ProductId = "4b760d46-10eb-4596-9d6f-da12e4e9a228", CartId = "1b760d44-10eb-4596-9d6f-da45e4e9a228", Amount = 4},
            new ProductToCartEntity {ProductId = "4b760d47-10eb-4596-9d6f-da12e4e9a228", CartId = "1b760d44-10eb-4596-9d6f-da45e4e9a228", Amount = 2},
            new ProductToCartEntity {ProductId = "4b760d48-10eb-4596-9d6f-da12e4e9a228", CartId = "1b760d44-10eb-4596-9d6f-da45e4e9a228", Amount = 4},
            new ProductToCartEntity {ProductId = "4b760d49-10eb-4596-9d6f-da12e4e9a228", CartId = "1b760d44-10eb-4596-9d6f-da45e4e9a228", Amount = 5},
            new ProductToCartEntity {ProductId = "4b760d44-10eb-4596-9d6f-da12e4e9a228", CartId = "4b760d44-10eb-4596-9d6f-da45e4e9a228", Amount = 6},
            new ProductToCartEntity {ProductId = "4b760d45-10eb-4596-9d6f-da12e4e9a228", CartId = "4b760d44-10eb-4596-9d6f-da45e4e9a228", Amount = 1},
            new ProductToCartEntity {ProductId = "4b760d46-10eb-4596-9d6f-da12e4e9a228", CartId = "4b760d44-10eb-4596-9d6f-da45e4e9a228", Amount = 4},
            new ProductToCartEntity {ProductId = "4b760d47-10eb-4596-9d6f-da12e4e9a228", CartId = "4b760d44-10eb-4596-9d6f-da45e4e9a228", Amount = 3}
        };


        public static readonly IList<ProductEntity> Products = new List<ProductEntity>
        {
            new ProductEntity {Id = "4b760d44-10eb-4596-9d6f-da12e4e9a228", Name = "Vr Glasses", EAN = RandomDigits(9), Description = "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum."},
            new ProductEntity {Id = "4b760d45-10eb-4596-9d6f-da12e4e9a228", Name = "Keyboard", EAN = RandomDigits(9), Description = "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum."},
            new ProductEntity {Id = "4b760d46-10eb-4596-9d6f-da12e4e9a228", Name = "Monitor", EAN = RandomDigits(9), Description = "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum."},
            new ProductEntity {Id = "4b760d47-10eb-4596-9d6f-da12e4e9a228", Name = "Ventilator", EAN = RandomDigits(9), Description = "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum."},
            new ProductEntity {Id = "4b760d48-10eb-4596-9d6f-da12e4e9a228", Name = "Charger", EAN = RandomDigits(9), Description = "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum."},
            new ProductEntity {Id = "4b760d49-10eb-4596-9d6f-da12e4e9a228", Name = "Cup", EAN = RandomDigits(9), Description = "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum."},
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