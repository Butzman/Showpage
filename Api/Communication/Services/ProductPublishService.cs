using Api.Communication.Hubs;
using Api.Communication.Interfaces;
using AutoMapper;
using Backend_Shared.Interfaces.DataServices;
using Backend_Shared.Models;
using Microsoft.AspNetCore.SignalR;
using Shared.Dtos;
using Shared.Interfaces;

namespace Api.Communication.Services
{
    public class ProductPublishService : PublishServiceBase<ProductHub, ProductDto, ProductModel, string>, IProductPublishService
    {
        private readonly IMapper _mapper;

        public ProductPublishService(IProductObservable observable, IMapper mapper, IHubContext<ProductHub, ISendChangesClient<ProductDto, string>> hubContext)
            : base(observable, mapper, hubContext)
        {
            _mapper = mapper;
        }
    }
}