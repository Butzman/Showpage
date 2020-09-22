using System.Collections.Generic;
using Shared.Interfaces;

namespace Shared.Dtos
{
    public class CartDto: IHaveAnId<string>
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }

        public IList<string> ProductIds { get; set; } = new List<string>();
    }
}