using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BlazorClient.Logic.Interfaces.Communication.Hub.Base;
using BlazorClient.Logic.Interfaces.DataServices.Base;
using DynamicData;
using DynamicData.Kernel;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Shared.Extensions;
using Shared.Interfaces;

namespace BlazorClient.Logic.Services.Communication.HubServices.Base
{
    public class HubServiceBase<TDto, TSaveDto, TId> : DisposableBase, IHubServiceBase<TSaveDto, TId>,
        ISendChangesClient<TDto, TId>
        where TDto : IHaveAnId<TId>
    {
        private readonly IAccessTokenProvider _tokenProvider;
        private readonly IConfiguration _configuration;
        private readonly IDataServiceBase<TDto, TId> _dataServiceBase;
        private readonly IMapper _mapper;
        private string _hubName;
        protected HubConnection _hubConnection;

        private BehaviorSubject<HubConnectionState> _hubConnectionStateSubject
            = new BehaviorSubject<HubConnectionState>(Microsoft.AspNetCore.SignalR.Client.HubConnectionState
                .Disconnected);

        private string _url;
        private AccessToken _prevToken;

        public HubServiceBase(
            IAccessTokenProvider tokenProvider,
            IConfiguration configuration,
            IDataServiceBase<TDto, TId> dataServiceBase,
            IMapper mapper)
        {
            _tokenProvider = tokenProvider;
            _configuration = configuration;
            _dataServiceBase = dataServiceBase;
            _mapper = mapper;
        }

        public string HubName
            => _hubName;

        public HubConnection HubConnection
            => _hubConnection;

        public IObservable<HubConnectionState> HubConnectionState
            => _hubConnectionStateSubject;

        public string HubConnectionId
            => _hubConnection.ConnectionId;

        public virtual async Task Save(TSaveDto saveDto)
            => await _hubConnection.InvokeAsync("Save", saveDto);

        public virtual async Task Delete(TId id)
            => await _hubConnection.InvokeAsync("Delete", id);

        public void InitializeHub(string hubName)
        {
            var apiUrl = _configuration.GetValue<string>("Urls:Api");

            if (string.IsNullOrEmpty(apiUrl))
                throw new ArgumentNullException(apiUrl);

            _url = apiUrl;
            _hubName = hubName;
        }

        public async Task StartConnections()
        {
            Observable
                .FromAsync(Connect)
                .RetryWithBackOff<Unit, Exception>((ex, i) => TimeSpan.FromSeconds(i + 1))
                .Subscribe();
        }

        private async Task Connect()
        {
            var tokenRequest = await _tokenProvider.RequestAccessToken();

            if (tokenRequest.TryGetToken(out var newToken))
            {
                if (newToken != _prevToken)
                {
                    SetupHubConnection(newToken);
                    _hubConnectionStateSubject.OnNext(Microsoft.AspNetCore.SignalR.Client.HubConnectionState
                        .Connecting);
                    _prevToken = newToken;
                }
            }

            if (_hubConnection == null) return;

            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(5));
            if (_hubConnection != null) await _hubConnection.StartAsync(cancellationTokenSource.Token);
            _hubConnectionStateSubject.OnNext(Microsoft.AspNetCore.SignalR.Client.HubConnectionState.Connected);
        }

        private void SetupHubConnection(AccessToken accessToken)
        {
            _hubConnection = HubConnectionBuilderExtensions
                .WithAutomaticReconnect(
                    new HubConnectionBuilder()
                        .WithUrl(
                            string.Concat(_url, _hubName),
                            options => { options.AccessTokenProvider = () => Task.FromResult(accessToken.Value); }
                        )
                    , new RetryPolicy()
                )
                .Build();


            _hubConnection.Closed += HubConnectionOnClosed;
            _hubConnection.Reconnecting += OnHubConnectionOnReconnecting;
            _hubConnection.Reconnected += HubConnectionOnReconnected;

            _hubConnection.On<IReadOnlyList<TDto>, IReadOnlyList<TId>>("SendChanges", SendChanges);
            _hubConnection.On<IReadOnlyList<TDto>>("SendAll", SendAll);
        }


        private async Task HubConnectionOnClosed(Exception arg)
        {
            _hubConnectionStateSubject.OnNext(Microsoft.AspNetCore.SignalR.Client.HubConnectionState.Disconnected);
            await Connect();
        }

        private Task HubConnectionOnReconnected(string arg)
        {
            _hubConnectionStateSubject.OnNext(Microsoft.AspNetCore.SignalR.Client.HubConnectionState.Connected);
            return Task.CompletedTask;
        }

        private Task OnHubConnectionOnReconnecting(Exception exception)
        {
            _hubConnectionStateSubject.OnNext(Microsoft.AspNetCore.SignalR.Client.HubConnectionState.Reconnecting);
            return Task.CompletedTask;
        }


        public async Task SendChanges(IReadOnlyList<TDto> addedOrUpdated, IReadOnlyList<TId> deletedIds)
        {
            _dataServiceBase.ModelCache.Edit(innerList =>
            {
                if (addedOrUpdated != null)
                    innerList.AddOrUpdate(addedOrUpdated);
                if (deletedIds != null)
                    innerList.Remove(deletedIds);
            });
        }

        public async Task SendAll(IReadOnlyList<TDto> allModels)
        {
            _dataServiceBase.ModelCache.AddOrUpdate(allModels);
        }
    }
}