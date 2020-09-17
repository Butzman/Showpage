using System;
using System.Collections.Generic;
using Dal.Entities;

namespace Dal
{
    public static class SeedingData
    {
        public static readonly IList<ProductEntity> Products = new List<ProductEntity>
        {
            new ProductEntity {Id = Guid.NewGuid().ToString(), Name = "Vr Glasses", EAN = RandomDigits(9)},
            new ProductEntity {Id = Guid.NewGuid().ToString(), Name = "Keyboard", EAN = RandomDigits(9)},
            new ProductEntity {Id = Guid.NewGuid().ToString(), Name = "Monitor", EAN = RandomDigits(9)},
            new ProductEntity {Id = Guid.NewGuid().ToString(), Name = "Ventilator", EAN = RandomDigits(9)},
            new ProductEntity {Id = Guid.NewGuid().ToString(), Name = "Charger", EAN = RandomDigits(9)},
            new ProductEntity {Id = Guid.NewGuid().ToString(), Name = "Cup", EAN = RandomDigits(9)},
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