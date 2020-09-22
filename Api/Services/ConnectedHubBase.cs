using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Backend_Shared.Interfaces.DataServices;
using Backend_Shared.Interfaces.DataServices.Base;
using Backend_Shared.Interfaces.DbServices;
using Backend_Shared.Interfaces.DbServices.Base;
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

        public ConnectedHubBase(IDbServiceBase<TModel,TSaveModel, TId> dbService, IDataServiceBase<TModel, TId> productDataService,
            IMapper mapper)
        {
            _dbService = dbService;
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


        public override async Task OnConnectedAsync()
        {
            var claims = Context.User.Claims;
            var userId = claims.FirstOrDefault(x=>x.Type == ClaimTypes.NameIdentifier)?.Value;
            
            if (Clients == null) return;

            var allModels = await _dbService.GetAll();
            
            if(allModels.Count == 0)  return;

            var allDtos = await GetDto(allModels.ToList());
            
            var listener = Clients.Caller;
            await SendAll(allDtos.ToList() , listener);
            await base.OnConnectedAsync();
        }


        protected virtual IClientProxy GetListener(TModel model)
            => Clients.All;

        protected virtual async Task<TDto> GetDto(TModel model)
            => _mapper.Map<TDto>(model);
        
        protected virtual async Task<IList<TDto>> GetDto(IList<TModel> model)
            => _mapper.Map<IList<TDto>>(model);
    }
}