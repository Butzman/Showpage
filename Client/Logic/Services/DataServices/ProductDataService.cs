using BlazorClient.Logic.Interfaces.DataServices;
using BlazorClient.Logic.Services.DataServices.Base;
using Shared.Dtos;

namespace BlazorClient.Logic.Services.DataServices
{
    public class ProductDataService: DataServiceBase<ProductDto, string>,IProductDataService
    {
        
    }
}