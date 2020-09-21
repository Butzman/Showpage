using System.Threading.Tasks;
using Api.Services;
using AutoMapper;
using Backend_Shared.Interfaces.DataServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Shared.Dtos;
using Shared.Models;

namespace Api.Communication.Hubs
{
    [Authorize]
    public class ProductHub: DataServiceHubBase<ProductDto,ProductModel, string>

    {
        public ProductHub(IProductDataService productDataService, IMapper mapper) : base(productDataService, mapper)
        {
        }

        public override Task OnConnectedAsync()
        {
            Caller.SendAsync("all" + nameof(ProductDto).Replace("Dto", ""), "Hello from the other side");
            return base.OnConnectedAsync();
        }
    }
}