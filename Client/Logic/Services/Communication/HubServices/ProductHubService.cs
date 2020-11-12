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
    public class ProductHubService : HubServiceBase<ProductDto, ProductDto, string>, IProductHubService
    {
        private readonly IToastService _toastService;

        public ProductHubService(IAccessTokenProvider accessTokenProvider,
         IConfiguration config,
          IProductDataService productDataService,
           IMapper mapper,
         IToastService toastService) : base(accessTokenProvider, config,
            productDataService, mapper)
        {
            _toastService = toastService;
        }

        public override async Task Save(ProductDto saveDto)
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

        public override async Task Delete(string id)
        {
            try
            {
                await base.Delete(id);
                _toastService.ShowSuccess("Successfully deletes " + id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while deleting " + id);
                Console.WriteLine(e);
                _toastService.ShowError("Error while deleting " + id);
            }
        }
    }
}