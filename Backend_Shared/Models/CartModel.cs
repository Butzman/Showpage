using System.Collections.Generic;
using Shared.Interfaces;

namespace Backend_Shared.Models
{
    public class CartModel:IHaveAnId<string>
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }

        public IList<string> ProductIds { get; set; } = new List<string>();
    }
}