using System.Threading.Tasks;
using AutoMapper;
using Backend_Shared.Interfaces.DbServices.Base;
using Microsoft.AspNetCore.SignalR;
using Shared.Interfaces;

namespace Api.Communication.Hubs.Base
{
    public class SendChangesHub<TDto, TModel, TSaveModel, TId> : Hub<ISendChangesClient<TDto, TId>>
        where TSaveModel : IHaveAnId<TId>
        where TDto : IHaveAnId<TId>
    {
        private readonly IMapper _mapper;
        private readonly IDbServiceBase<TModel, TSaveModel, TId> _dbServiceBase;

        protected ISendChangesClient<TDto, TId> Caller
            => Clients.Client(this.Context.ConnectionId);

        public SendChangesHub(IMapper mapper, IDbServiceBase<TModel, TSaveModel, TId> dbServiceBase)
        {
            _mapper = mapper;
            _dbServiceBase = dbServiceBase;
        }

        public virtual async Task Save(TDto dto)
        {
            var model = _mapper.Map<TSaveModel>(dto);
            await _dbServiceBase.Save(model);
        }
    }
}