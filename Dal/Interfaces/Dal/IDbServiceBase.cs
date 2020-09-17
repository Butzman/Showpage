using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dal.Interfaces.Dal
{
    public interface IDbServiceBase<TModel, TSaveModel, TId>
    {
        Task<TModel> Save(TSaveModel model);
        Task<TModel> Delete(TId id);
        Task<IReadOnlyList<TModel>> GetAll();
        Task<TModel> Get(TId id);
        Task<IList<TModel>> Get(Expression<Func<TModel,bool>> filter);
    }
}