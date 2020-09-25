using Api.Communication.Hubs;
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

        public ProductPublishService(IProductObservableOfChangeSet observableOfChangeSet, IMapper mapper, IHubContext<ProductHub, ISendChangesClient<ProductDto, string>> hubContext)
            : base(observableOfChangeSet, mapper, hubContext)
        {
            _mapper = mapper;
        }
    }
}