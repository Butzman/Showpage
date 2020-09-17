using Dal.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Dal.Entities
{
    public class ProductEntity : EntityBase<string>
    {
        public string Name { get; set; }
        public string EAN { get; set; }

        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
        }
    }
}