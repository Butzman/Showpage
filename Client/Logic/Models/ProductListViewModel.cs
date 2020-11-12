using Shared.Dtos;

namespace BlazorClient.Logic.Models
{
    public class ProductListViewModel
    {
        public ProductDto ProductDto { get; set; }
        public bool IsInLocalCart { get; set; }
    }
}