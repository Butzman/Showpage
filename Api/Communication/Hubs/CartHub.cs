using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Api.Services;
using AutoMapper;
using Backend_Shared.Interfaces.DataServices;
using Backend_Shared.Interfaces.DbServices;
using Backend_Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Shared.Dtos;

namespace Api.Communication.Hubs
{
    [Authorize]
    public class CartHub : ConnectedHubBase<CartDto, CartModel, CartModel, string>
    {
        private readonly ICartDbService _dbService;

        public CartHub(ICartDbService dbService, ICartObservableOfChangeSet cartObservableOfChangeSet, IMapper mapper) : base(dbService, cartObservableOfChangeSet, mapper)
        {
            _dbService = dbService;
        }

        public override async Task OnConnectedAsync()
        {
            var claims = Context.User.Claims;
            var userId = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (Clients == null) return;

            var allModels = await _dbService.GetAll();

            if (allModels.Count == 0) return;

            var filteredDtos = await GetDto(allModels.Where(x => x.UserId.Equals(userId)).ToList());

            var listener = Clients.Caller;
            await SendAll(filteredDtos.ToList(), listener);
            
        }
    }
}