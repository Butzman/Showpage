using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorClient.Logic.Interfaces.Communication.Hub.Base
{
    public interface IHubServiceBase<TSaveDto, TId>
    {
        string HubName { get; }
        HubConnection HubConnection { get; }
        IObservable<HubConnectionState> HubConnectionState { get; }
        string HubConnectionId { get; }
        void InitializeHub(string hubName);
        Task StartConnections();

        Task Save(TSaveDto saveDto);
        Task Delete(TId id);
    }
}