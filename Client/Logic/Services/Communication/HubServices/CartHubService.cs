using System;
using System.Threading.Tasks;
using AutoMapper;
using BlazorClient.Logic.Interfaces.Communication.Hub;
using BlazorClient.Logic.Interfaces.DataServices;
using BlazorClient.Logic.Services.Communication.HubServices.Base;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;
using Shared.Dtos;

namespace BlazorClient.Logic.Services.Communication.HubServices
{
    public class CartHubService : HubServiceBase<CartDto, CartDto, string>, ICartHubService
    {
        private readonly IToastService _toastService;

        public CartHubService(IAccessTokenProvider tokenProvider,
            IConfiguration configuration,
            ICartDataService dataServiceBase,
            IMapper mapper,
            IToastService toastService) : base(tokenProvider, configuration, dataServiceBase, mapper)
        {
            _toastService = toastService;
        }

        public override async Task Save(CartDto saveDto)
        {
            try
            {
                await base.Save(saveDto);
                _toastService.ShowSuccess("Successfully saved " + saveDto.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while saving " + saveDto.Id + ", " + saveDto.Name);
                Console.WriteLine(e);
                _toastService.ShowError("Error while saving " + saveDto.Name);
            }
        }
    }
}