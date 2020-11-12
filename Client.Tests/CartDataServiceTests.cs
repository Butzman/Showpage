using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using BlazorClient.Logic.Interfaces.DataServices;
using BlazorClient.Logic.Models;
using BlazorClient.Logic.Services.DataServices;
using Blazored.LocalStorage;
using DynamicData;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace BlazorClient.Tests
{
    public class CartDataServiceTests
    
    {
        private readonly Mock<ILocalStorageService> _localStorageServiceMock = new Mock<ILocalStorageService>();
        
        private ICartDataService GetCartDataService() => new CartDataService(_localStorageServiceMock.Object);

        [Test]
        public async Task AddOrUpdate_ItemTo_LocalSourceCache()
        {
            var cartDataService = GetCartDataService();
            var observable = cartDataService.LocalCartSourceCache.Connect().FirstAsync().ToTask();

            cartDataService.LocalCartSourceCache.AddOrUpdate(new ProductInLocalCartModel{ProductId = "1",Amount = 2});

            var result = await observable;

            result.Adds.ShouldBe(1);
        }

        [Test]
        public async Task CountChanged_GetsTriggered_onAddOrUpdate_LocalSourceCache()
        {
            var cartDataService = GetCartDataService();
            cartDataService.LocalCartSourceCache.AddOrUpdate(new ProductInLocalCartModel{ProductId = "1",Amount = 2});
            
            var obs = cartDataService.LocalCartSourceCache.CountChanged.Skip(1).FirstAsync().ToTask();
            
            cartDataService.LocalCartSourceCache.AddOrUpdate(new ProductInLocalCartModel{ProductId = "2",Amount = 2});

            var result = 5;
            result = await obs;
            
            result.ShouldBe(2);
        }
    }
}