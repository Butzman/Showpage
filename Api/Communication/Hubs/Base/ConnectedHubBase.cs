using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend_Shared.Interfaces.DbServices.Base;
using Microsoft.AspNetCore.SignalR;
using Shared.Interfaces;

namespace Api.Communication.Hubs.Base
{
    public class ConnectedHub<TDto, TModel, TSaveModel, TId> : Hub<ISendChangesClient<TDto, TId>>
        where TDto : IHaveAnId<TId>
        where TModel : IHaveAnId<TId>
        where TSaveModel : IHaveAnId<TId>
    {
        private readonly IDbServiceBase<TModel, TSaveModel, TId> _dbService;
        private readonly IMapper _mapper;

        public ConnectedHub(
            IDbServiceBase<TModel, TSaveModel, TId> dbService,
            IMapper mapper)
        {
            _dbService = dbService;
            _mapper = mapper;
        }

        public virtual async Task Save(TDto dto)
        {
            var model = _mapper.Map<TSaveModel>(dto);
            await _dbService.Save(model);
        }

        public override async Task OnConnectedAsync()
        {
            if (Clients == null) return;

            var allModels = await _dbService.GetAll();

            if (allModels.Count == 0) return;

            var allDtos = _mapper.Map<IList<TDto>>(allModels);

            await Clients.Caller.SendAll(allDtos.ToList());
            await base.OnConnectedAsync();
        }
    }
}