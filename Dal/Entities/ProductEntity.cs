using Dal.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Entities
{
    public class ProductEntity : EntityBase<string>, IEntityTypeConfiguration<ProductEntity>
    {
        public string Name { get; set; }
        public string EAN { get; set; }

        public string Description { get; set; }

        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}