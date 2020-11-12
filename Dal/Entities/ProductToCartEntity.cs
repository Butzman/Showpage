using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Entities
{
    public class ProductToCartEntity : IEntityTypeConfiguration<ProductToCartEntity>
    {
        public string ProductId { get; set; }

        public string CartId { get; set; }
        public CartEntity CartEntity { get; set; }


        public int Amount { get; set; }


        public void Configure(EntityTypeBuilder<ProductToCartEntity> builder)
        {
            builder
                .HasKey(x => new { x.CartId,   x.ProductId});
            builder
                .HasOne(x => x.CartEntity)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CartId);

        }
    }
}