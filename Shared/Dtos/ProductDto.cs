using Shared.Dtos.Base;

namespace Shared.Dtos
{
    public class ProductDto: DtoBase<string>
    {
        public string Name { get; set; }
        public string EAN { get; set; }
    }
}