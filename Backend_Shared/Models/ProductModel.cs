using Backend_Shared.Models.Base;

namespace Backend_Shared.Models
{
    public class ProductModel: ModelBase<string>
    {
        public string Name { get; set; }
        public string EAN { get; set; }
    }
}