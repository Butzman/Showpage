using Api.Dtos.Base;

namespace Api.Dtos
{
    public class ProductDto: DtoBase<string>
    {
        public string Name { get; set; }
        public string EAN { get; set; }
    }
}