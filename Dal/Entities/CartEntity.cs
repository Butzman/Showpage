using System.Collections.Generic;
using Dal.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Dal.Entities
{
    public class CartEntity : EntityBase<string>
    {
        public string UserId { get; set; }
        public string Name { get; set; }

        public IList<string> ProductIds { get; set; } = new List<string>();

        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
        }
    }
}