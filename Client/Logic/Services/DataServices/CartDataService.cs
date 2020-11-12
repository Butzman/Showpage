using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using BlazorClient.Logic.Interfaces.DataServices;
using BlazorClient.Logic.Models;
using BlazorClient.Logic.Services.DataServices.Base;
using Blazored.LocalStorage;
using DynamicData;
using Shared.Dtos;
using Shared.Extensions;

namespace BlazorClient.Logic.Services.DataServices
{
    public class CartDataService : DataServiceBase<CartDto, string>, ICartDataService
    {
        private readonly ILocalStorageService _localStorageService;

        public SourceCache<ProductInLocalCartModel, string> LocalCartSourceCache { get; }
            = new SourceCache<ProductInLocalCartModel, string>(x => x.ProductId);


        public IObservable<CartDto> LoadedCartDtoObservable
            => _loadedCartDtoSubject.AsObservable();

        private readonly ISubject<CartDto> _loadedCartDtoSubject = new ReplaySubject<CartDto>(1);

        private string _currentLoadedCartId;

        public CartDataService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;

            Observable.FromAsync(GetCartFromLocalStore)
                .Subscribe(x =>
                {
                    if (x != null)
                        LocalCartSourceCache.AddOrUpdate(x);
                })
                .DisposeWith(this);

            LocalCartSourceCache
                .Connect()
                .ToCollection()
                .SelectMany(UpdateCartInLocalStore)
                .Subscribe()
                .DisposeWith(this);

            Observable.FromAsync(GetCartIdFromLocalStore)
                .Subscribe(cartId =>
                {
                    if (cartId == null) return;
                    _currentLoadedCartId = cartId;
                    _loadedCartDtoSubject.OnNext(GetCartDtoFromId(cartId));
                })
                .DisposeWith(this);

            ModelCache
                .Connect()
                .OnItemUpdated((dto, prevDto) => EmitLoadedCartDto(dto))
                .OnItemAdded(EmitLoadedCartDto)
                .Subscribe()
                .DisposeWith(this);
        }

        private void EmitLoadedCartDto(CartDto dto)
        {
            if (dto.Id.Equals(_currentLoadedCartId))
                _loadedCartDtoSubject.OnNext(dto);
        }

        public async Task ChangeLoadedCartIdAsync(string cartId)
        {
            await UpdateCartIdInLocalStore(cartId);
            _currentLoadedCartId = cartId;
            _loadedCartDtoSubject.OnNext(GetCartDtoFromId(cartId));
        }

        public async Task ResetLoadedCartAsync()
        {
            await UpdateCartInLocalStore(new List<ProductInLocalCartModel>());
            await UpdateCartIdInLocalStore(null);
            _currentLoadedCartId = null;
            _loadedCartDtoSubject.OnNext(null);
            LocalCartSourceCache.Clear();
        }

        private CartDto GetCartDtoFromId(string cartId)
            => ModelCache.Items.FirstOrDefault(cartDto => cartDto.Id.Equals(cartId));

        private async Task<IReadOnlyCollection<ProductInLocalCartModel>> GetCartFromLocalStore()
        {
            return await _localStorageService.GetItemAsync<IReadOnlyCollection<ProductInLocalCartModel>>("Cart");
        }

        private async Task<Unit> UpdateCartInLocalStore(IReadOnlyCollection<ProductInLocalCartModel> list)
        {
            await _localStorageService.SetItemAsync("Cart", list);
            return Unit.Default;
        }

        private async Task<string> GetCartIdFromLocalStore()
        {
            return await _localStorageService.GetItemAsync<string>("CartId");
        }

        private async Task<Unit> UpdateCartIdInLocalStore(string cartId)
        {
            await _localStorageService.SetItemAsync("CartId", cartId);
            return Unit.Default;
        }
    }
}