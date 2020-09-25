using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Backend_Shared.Interfaces.DbServices.Base;
using DynamicData;
using Shared.Interfaces;

namespace Api.Communication.Hubs.Base
{
    public class ConnectedHub<TDto, TModel, TSaveModel, TId> : SendChangesHub<TDto, TModel, TSaveModel, TId>
        where TDto : IHaveAnId<TId>
        where TModel : IHaveAnId<TId>
        where TSaveModel : IHaveAnId<TId>
    {
        private readonly IDbServiceBase<TModel, TSaveModel, TId> _dbService;
        private readonly IMapper _mapper;

        public ConnectedHub(
            IDbServiceBase<TModel, TSaveModel, TId> dbService,
            IMapper mapper
        ) : base(mapper, dbService)
        {
            _dbService = dbService;
            _mapper = mapper;
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