﻿using System;
using System.Collections.Generic;
using DynamicData;

namespace Shared.Interfaces.DataServices
{
    public interface IDataServiceBase<TModel, TId>
        where TModel : IHaveAnId<TId>
    {
        IObservable<ChangeSet<TModel, TId>> ObservableOfChangeSet { get; }
        IObservable<IList<TModel>> ObservableOfAddOrUpdates { get; }
        IObservable<IList<TModel>> ObservableOfRemoves { get; }
        void HandleAddOrUpdate(TModel model);
        void HandleAddOrUpdate(IEnumerable<TModel> models);
        void HandleRemove(TId id);
        void HandleRemove(IEnumerable<TId> ids);
    }
}