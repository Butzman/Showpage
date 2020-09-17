using Dal.Entities.Base;

namespace Dal.Entities
{
    public class ProductEntity: EntityBase<string>
    {
        public string Name { get; set; }
        public string EAN { get; set; }
    }
}