using System;
using System.Threading.Tasks;
using BlazorClient.Logic.Interfaces.DataServices.Base;
using BlazorClient.Logic.Models;
using DynamicData;
using Shared.Dtos;

namespace BlazorClient.Logic.Interfaces.DataServices
{
    public interface ICartDataService: IDataServiceBase<CartDto,string>
    {
        SourceCache<ProductInLocalCartModel, string> LocalCartSourceCache { get; }
        IObservable<CartDto> LoadedCartDtoObservable { get;  }
        Task ChangeLoadedCartIdAsync(string cartId);
        Task ResetLoadedCartAsync();
    }
}