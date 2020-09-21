using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Api.Services
{
    public class SendChangesHubBase<TDto, TId> : Hub
    {
        protected IClientProxy Caller
            => Clients.Client(this.Context.ConnectionId);

        protected virtual async Task SendChanges(IReadOnlyList<TDto> addedOrUpdated, IReadOnlyList<TId> deletedIds, IClientProxy listener)
            => await listener.SendAsync("changes" + typeof(TDto).Name.Replace("Dto", ""), addedOrUpdated, deletedIds, typeof(TDto).Name.Replace("Dto", ""));
        
        protected virtual async Task SendAll(IReadOnlyList<TDto> allModels, IClientProxy listener)
            => await listener.SendAsync("all" + typeof(TDto).Name.Replace("Dto", ""), allModels);
        
    }
}