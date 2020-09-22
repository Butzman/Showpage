using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Api.Services;
using AutoMapper;
using Backend_Shared.Interfaces.DataServices.Base;
using Backend_Shared.Interfaces.DbServices;
using Backend_Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Shared.Dtos;

namespace Api.Communication.Hubs
{
    [Authorize]
    public class CartHub : ConnectedHubBase<CartDto, CartModel, CartModel, string>
    {
        private readonly ICartDbService _dbService;

        public CartHub(ICartDbService dbService, IDataServiceBase<CartModel, string> productDataService, IMapper mapper) : base(dbService, productDataService, mapper)
        {
            _dbService = dbService;
        }

        public override async Task OnConnectedAsync()
        {
            var claims = Context.User.Claims;
            var userId = claims.FirstOrDefault(x=>x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (Clients == null) return;

            var allModels = await _dbService.GetAll();

            if (allModels.Count == 0) return;

            var allDtos = await GetDto(allModels.ToList());

            var listener = Clients.Caller;
            await SendAll(allDtos.ToList(), listener);
            await base.OnConnectedAsync();
        }
    }
}