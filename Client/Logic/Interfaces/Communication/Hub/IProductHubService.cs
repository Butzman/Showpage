using BlazorClient.Logic.Interfaces.Communication.Hub.Base;
using Shared.Dtos;

namespace BlazorClient.Logic.Interfaces.Communication.Hub
{
    public interface IProductHubService : IHubServiceBase<ProductDto, string>
    {
    }
}