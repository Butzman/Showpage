using BlazorClient.Logic.Interfaces.DataServices.Base;
using Shared.Dtos;

namespace BlazorClient.Logic.Interfaces.DataServices
{
    public interface IProductDataService : IDataServiceBase<ProductDto, string>
    {
    }
}