using System;
using System.Collections.Generic;
using DynamicData;
using Shared.Interfaces;

namespace Backend_Shared.Interfaces.DataServices.Base
{
    public interface IDataServiceBase<TModel, TId>
        where TModel : IHaveAnId<TId>
    {
        void HandleAddOrUpdate(TModel model);
        void HandleAddOrUpdate(IEnumerable<TModel> models);
        void HandleRemove(TId id);
        void HandleRemove(IEnumerable<TId> ids);
    }
}