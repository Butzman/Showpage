using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Api.Services;
using AutoMapper;
using Backend_Shared.Interfaces.DataServices;
using Backend_Shared.Interfaces.DbServices;
using Backend_Shared.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Shared.Dtos;

namespace Api.Communication.Hubs
{
    [Authorize]
    public class ProductHub : ConnectedHubBase<ProductDto, ProductModel, ProductModel, string>

    {
        public ProductHub(IProductDbService dbService, IProductDataService productDataService, IMapper mapper, ILogger<ProductHub> logger) : base(dbService, productDataService, mapper)
        {
        }
    }
}