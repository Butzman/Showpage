using System.Collections.Generic;
using Shared.Interfaces;

namespace Shared.Dtos
{
    public class CartDto: IHaveAnId<string>
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }

        public IList<ProductToCartDto> Products { get; set; } = new List<ProductToCartDto>();
    }
}