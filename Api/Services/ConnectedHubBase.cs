using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Backend_Shared.Interfaces.DbServices.Base;
using DynamicData;
using Microsoft.AspNetCore.SignalR;
using Shared.Interfaces;

namespace Api.Services
{
    public class ConnectedHubBase<TDto, TModel, TSaveModel, TId> : SendChangesHubBase<TDto, TId>
        where TDto : IHaveAnId<TId>
        where TModel : IHaveAnId<TId>
        where TSaveModel : IHaveAnId<TId>
    {
        private readonly IDbServiceBase<TModel, TSaveModel, TId> _dbService;
        private readonly IMapper _mapper;

        public ConnectedHubBase(IDbServiceBase<TModel, TSaveModel, TId> dbService, IObservable<ChangeSet<TModel, TId>> observableOfChangeSet,
            IMapper mapper)
        {
            _dbService = dbService;
            _mapper = mapper;

            observableOfChangeSet
                .WhereReasonsAre(ChangeReason.Add, ChangeReason.Update)
                .Subscribe(async x => await SendAddedOrUpdated(x));
            observableOfChangeSet
                .WhereReasonsAre(ChangeReason.Remove)
                .Subscribe(async x => await SendDeletedByIds(x));
        }

        protected virtual async Task SendAddedOrUpdated(IChangeSet<TModel, TId> changeSet)
        {
            if (Clients == null) return;

            var models = changeSet.Select(change => change.Current).ToList();

            var dtos = await GetDto(models);
            var listener = GetListener();
            await SendChanges(new List<TDto> {dtos}, null, listener);
        }

        protected virtual async Task SendDeletedByIds(IChangeSet<TModel, TId> changeSet)
        {
            if (Clients == null) return;

            var ids = changeSet.Select(change => change.Key).ToList();
            
            var listener = GetListener();
            await SendChanges(null, new List<TId> {ids}, listener);
        }


        public override async Task OnConnectedAsync()
        {
            var claims = Context.User.Claims;
            var userId = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (Clients == null) return;

            var allModels = await _dbService.GetAll();

            if (allModels.Count == 0) return;

            var allDtos = await GetDto(allModels.ToList());

            var listener = Clients.Caller;
            await SendAll(allDtos.ToList(), listener);
            await base.OnConnectedAsync();
        }


        protected virtual IClientProxy GetListener()
            => Clients.All;

        protected virtual async Task<TDto> GetDto(TModel model)
            => _mapper.Map<TDto>(model);

        protected virtual async Task<IList<TDto>> GetDto(IList<TModel> model)
            => _mapper.Map<IList<TDto>>(model);
    }
}