using Api.Communication.Hubs;
using AutoMapper;
using Backend_Shared.Interfaces.DataServices;
using Backend_Shared.Models;
using Microsoft.AspNetCore.SignalR;
using Shared.Dtos;
using Shared.Interfaces;

namespace Api.Communication.Services
{
    public class CartPublishService: PublishServiceBase<CartHub,CartDto,CartModel,string>, ICartPublishService
    {
        public CartPublishService(ICartObservableOfChangeSet observableOfChangeSet, IMapper mapper, IHubContext<CartHub, ISendChangesClient<CartDto, string>> hubContext) : base(observableOfChangeSet, mapper, hubContext)
        {
        }
    }
}