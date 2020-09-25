using Api.Communication.Hubs.Base;
using Api.Communication.Services;
using AutoMapper;
using Backend_Shared.Interfaces.DbServices;
using Backend_Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Shared.Dtos;

namespace Api.Communication.Hubs
{
    [Authorize]
    public class ProductHub : ConnectedHub<ProductDto, ProductModel, ProductModel, string>

    {
        public ProductHub(
            IProductPublishService productPublishService,
            IProductDbService dbService,
            IMapper mapper
        ) : base(dbService, mapper)
        {
            var test = productPublishService;
        }
    }
}