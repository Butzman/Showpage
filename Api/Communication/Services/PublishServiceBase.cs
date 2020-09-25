using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Api.Communication.Interfaces;
using AutoMapper;
using DynamicData;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Shared.Interfaces;

namespace Api.Communication.Services
{
    public class PublishServiceBase<THub, TDto, TModel, TId> : IPublishServiceBase
        where TDto : IHaveAnId<TId>
        where TModel : IHaveAnId<TId>
        where THub : Hub<ISendChangesClient<TDto, TId>>
    {
        private readonly IMapper _mapper;
        private readonly IHubContext<THub, ISendChangesClient<TDto, TId>> _hubContext;

        public PublishServiceBase(
            IObservable<ChangeSet<TModel,TId>> observable,
            IMapper mapper,
            IHubContext<THub, ISendChangesClient<TDto, TId>> hubContext
        )
        {
            _mapper = mapper;
            _hubContext = hubContext;
            observable
                .WhereReasonsAre(ChangeReason.Add, ChangeReason.Update)
                .SelectMany(SendAddedOrUpdated)
                .Subscribe();
            observable
                .WhereReasonsAre(ChangeReason.Remove)
                .SelectMany(SendDeletedByIds)
                .Subscribe();
        }

        protected virtual async Task<Unit> SendAddedOrUpdated(IChangeSet<TModel, TId> changeSet)
        {
            if (_hubContext.Clients == null) return Unit.Default;

            var models = changeSet.Select(change => change.Current).ToList();

            var dtos = _mapper.Map<List<TDto>>(models);
            await GetListener().SendChanges(new List<TDto> {dtos}, null);

            return Unit.Default;
        }

        protected virtual async Task<Unit> SendDeletedByIds(IChangeSet<TModel, TId> changeSet)
        {
            if (_hubContext.Clients == null) return Unit.Default;

            var ids = changeSet.Select(change => change.Key).ToList();
            await GetListener().SendChanges(null, new List<TId> {ids});
            return Unit.Default;
        }


        protected virtual ISendChangesClient<TDto, TId> GetListener()
            => _hubContext.Clients.All;
    }
}