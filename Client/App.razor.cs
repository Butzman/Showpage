using System.Threading.Tasks;
using BlazorClient.Logic.Interfaces.Communication.Hub;
using Microsoft.AspNetCore.Components;
using Shared.Helpers;

namespace BlazorClient
{
    public class AppRazor : ComponentBase
    {
        [Inject] private IProductHubService ProductHubService { get; set; }
        [Inject] private ICartHubService CartHubService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ProductHubService.InitializeHub(SignalrUrls.ProductsHub);
            CartHubService.InitializeHub(SignalrUrls.CartsHub);

            await ProductHubService.StartConnections();
            await CartHubService.StartConnections();

            await base.OnInitializedAsync();
        }
    }
}