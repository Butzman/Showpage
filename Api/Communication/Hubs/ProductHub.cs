using Api.Dtos;
using Api.Services;
using AutoMapper;
using Shared.Interfaces.DataServices;
using Shared.Models;

namespace Api.Communication.Hubs
{
    public abstract class ProductHub: DataServiceHubBase<ProductDto,ProductModel, string>

    {
        protected ProductHub(IProductDataService dataBaseDataService, IMapper mapper) : base(dataBaseDataService, mapper)
        {
        }
    }
}