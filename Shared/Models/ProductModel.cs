using Shared.Models.Base;

namespace Shared.Models
{
    public class ProductModel: ModelBase<string>
    {
        public string Name { get; set; }
        public string EAN { get; set; }
    }
}