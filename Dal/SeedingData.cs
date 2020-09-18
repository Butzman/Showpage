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
                Id = Guid.NewGuid().ToString(),
                Name = "First Cart",
                ProductIds = new List<string>
                {
                    "4b760d44-10eb-4596-9d6f-da12e4e9a228",
                    "4b760d45-10eb-4596-9d6f-da12e4e9a228",
                    "4b760d47-10eb-4596-9d6f-da12e4e9a228",
                },
                UserId = "4b760d43-10eb-4596-9d6f-da12e4e9a228"
            }, 
            new CartEntity
            {
                Id = Guid.NewGuid().ToString(),
                Name = "First Cart",
                ProductIds = new List<string>
                {
                    "4b760d46-10eb-4596-9d6f-da12e4e9a228",
                    "4b760d47-10eb-4596-9d6f-da12e4e9a228",
                    "4b760d48-10eb-4596-9d6f-da12e4e9a228",
                    "4b760d49-10eb-4596-9d6f-da12e4e9a228",
                },
                UserId = "4b760d43-10eb-4596-9d6f-da12e4e9a228"
            }
        };

        public static readonly IList<ProductEntity> Products = new List<ProductEntity>
        {
            new ProductEntity {Id = "4b760d44-10eb-4596-9d6f-da12e4e9a228", Name = "Vr Glasses", EAN = RandomDigits(9)},
            new ProductEntity {Id = "4b760d45-10eb-4596-9d6f-da12e4e9a228", Name = "Keyboard", EAN = RandomDigits(9)},
            new ProductEntity {Id = "4b760d46-10eb-4596-9d6f-da12e4e9a228", Name = "Monitor", EAN = RandomDigits(9)},
            new ProductEntity {Id = "4b760d47-10eb-4596-9d6f-da12e4e9a228", Name = "Ventilator", EAN = RandomDigits(9)},
            new ProductEntity {Id = "4b760d48-10eb-4596-9d6f-da12e4e9a228", Name = "Charger", EAN = RandomDigits(9)},
            new ProductEntity {Id = "4b760d49-10eb-4596-9d6f-da12e4e9a228", Name = "Cup", EAN = RandomDigits(9)},
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