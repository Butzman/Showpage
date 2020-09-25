using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Api.Communication.Hubs.Base;
using Api.Communication.Interfaces;
using Api.Communication.Services;
using AutoMapper;
using Backend_Shared.Interfaces.DbServices;
using Backend_Shared.Models;
using Shared.Dtos;

namespace Api.Communication.Hubs
{
    public class CartHub : ConnectedHub<CartDto, CartModel, CartModel, string>
    {
        private readonly ICartDbService _dbService;
        private readonly IMapper _mapper;

        public CartHub(
            ICartPublishService cartPublishService,
            ICartDbService dbService,
            IMapper mapper) : base(dbService, mapper)
        {
            _dbService = dbService;
            _mapper = mapper;
        }

        public override async Task OnConnectedAsync()
        {
            var claims = Context.User.Claims;
            var userId = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (Clients == null) return;

            var allModels = await _dbService.GetAll();

            if (allModels.Count == 0) return;

            var filteredDtos = _mapper.Map<IList<CartDto>>(allModels.Where(x => x.UserId.Equals(userId)).ToList());

            await Clients.Caller.SendAll(filteredDtos.ToList());
        }
    }
}