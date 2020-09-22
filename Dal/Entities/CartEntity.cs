using System.Collections.Generic;
using Dal.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Entities
{
    public class CartEntity : EntityBase<string>, IEntityTypeConfiguration<CartEntity>
    {
        public string UserId { get; set; }
        public string Name { get; set; }

        public IList<ProductToCartEntity> Products { get; set; }= new List<ProductToCartEntity>();
        
        public void Configure(EntityTypeBuilder<CartEntity> builder)
        {
        }
    }
}