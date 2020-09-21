using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Backend_Shared.Interfaces.DataServices;
using Microsoft.AspNetCore.SignalR;
using Shared.Interfaces;

namespace Api.Services
{
    public class DataServiceHubBase<TDto, TModel, TId> : SendChangesHubBase<TDto, TId>
        where TDto : IHaveAnId<TId>
        where TModel : IHaveAnId<TId>
    {
        private readonly IMapper _mapper;

        public DataServiceHubBase(IDataServiceBase<TModel, TId> productDataService,
            IMapper mapper)
        {
            _mapper = mapper;

            productDataService.ObservableOfAddOrUpdates
                .Subscribe(async x => await SendAddedOrUpdated(x));
            productDataService.ObservableOfRemoves
                .Subscribe(async x => await SendDeletedByIds(x));
        }

        protected virtual async Task SendAddedOrUpdated(IEnumerable<TModel> models)
        {
            if (Clients == null) return;

            foreach (var model in models)
            {
                var dto = await GetDto(model);
                var listener = GetListener(model);
                await SendChanges(new List<TDto> {dto}, null, listener);
            }
        }

        protected virtual async Task SendDeletedByIds(IEnumerable<TModel> models)
        {
            if (Clients == null) return;

            foreach (var model in models)
            {
                var listener = GetListener(model);
                await SendChanges(null, new List<TId> {model.Id}, listener);
            }
        }

        protected virtual IClientProxy GetListener(TModel model)
            => Clients.All;

        protected virtual async Task<TDto> GetDto(TModel model)
            => _mapper.Map<TDto>(model);
    }
}