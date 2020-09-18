using System.Threading.Tasks;
using AutoMapper;
using Dal.Interfaces.Dal;
using Microsoft.Extensions.Logging;
using Shared.Interfaces;
using Shared.Interfaces.DataServices;
using Shared.Interfaces.DbServices.Base;

namespace Dal.Services.Base
{
    public class ConnectedDbServiceBase<TEntity, TModel, TSaveModel, TId> : DbServiceBase<TEntity, TModel, TSaveModel, TId>, IConnectedDbServiceBase<TModel, TSaveModel, TId>
        where TModel : class, IHaveAnId<TId>
        where TEntity : class, IHaveAnId<TId>
        where TSaveModel : IHaveAnId<TId>
    {
        private readonly IDataServiceBase<TModel, TId> _dataServiceBase;

        public ConnectedDbServiceBase(
            IDataServiceBase<TModel, TId> dataServiceBase,
            IContextFactory contextFactory,
            ILogger logger,
            IMapper mapper
        ) : base(contextFactory, logger, mapper)
        {
            _dataServiceBase = dataServiceBase;
        }

        public override async Task<TModel> Save(TSaveModel model)
        {
            var savedModel = await base.Save(model);
            if (savedModel != null)
                _dataServiceBase.HandleAddOrUpdate(savedModel);

            return savedModel;
        }

        public override async Task<TModel> Delete(TId id)
        {
            var deletedModel = await base.Delete(id);
            if(deletedModel != null)
                _dataServiceBase.HandleRemove(deletedModel.Id);
            
            return deletedModel;
        }
    }
}