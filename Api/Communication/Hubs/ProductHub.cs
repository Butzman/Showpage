using Api.Services;
using AutoMapper;
using Backend_Shared.Interfaces.DataServices;
using Backend_Shared.Interfaces.DbServices;
using Backend_Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Shared.Dtos;

namespace Api.Communication.Hubs
{
    public class ProductHub : DataServiceHubBase<ProductDto, ProductModel, ProductModel, string>

    {
        public ProductHub(IProductDbService dbService, IProductDataService productDataService, IMapper mapper) : base(dbService, productDataService, mapper)
        {
        }
    }
}