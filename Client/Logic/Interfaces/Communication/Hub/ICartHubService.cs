using BlazorClient.Logic.Interfaces.Communication.Hub.Base;
using Shared.Dtos;

namespace BlazorClient.Logic.Interfaces.Communication.Hub
{
    public interface ICartHubService: IHubServiceBase<CartDto, string>
    {
        
    }
}