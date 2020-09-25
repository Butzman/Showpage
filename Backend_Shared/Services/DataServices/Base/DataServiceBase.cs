using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Backend_Shared.Interfaces.DataServices.Base;
using DynamicData;
using DynamicData.Kernel;
using Shared.Extensions;
using Shared.Interfaces;

namespace Backend_Shared.Services.DataServices.Base
{
    public class DataServiceBase<TModel, TId> : DisposableBase, IDataServiceBase<TModel, TId>, IObservable<ChangeSet<TModel, TId>>
        where TModel : IHaveAnId<TId>
    {
       

        protected readonly Subject<ChangeSet<TModel, TId>> SubjectOfChangeSet;

        public DataServiceBase()
        {
            SubjectOfChangeSet = new Subject<ChangeSet<TModel, TId>>()
                .DisposeWith(this);
        }

        public void HandleAddOrUpdate(TModel model)
        {
            var changeSet = new ChangeSet<TModel, TId>();
            AddOrUpdate(changeSet, model);
            SubjectOfChangeSet.OnNext(changeSet);
        }

        public void HandleAddOrUpdate(IEnumerable<TModel> models)
        {
            var changeSet = new ChangeSet<TModel, TId>();
            models.ForEach(model => AddOrUpdate(changeSet, model));
            SubjectOfChangeSet.OnNext(changeSet);
        }

        public void HandleRemove(TId id)
        {
            var changeSet = new ChangeSet<TModel, TId>();
            Remove(changeSet, id);
            SubjectOfChangeSet.OnNext(changeSet);
        }

        public void HandleRemove(IEnumerable<TId> ids)
        {
            var changeSet = new ChangeSet<TModel, TId>();
            ids.ForEach(id => Remove(changeSet, id));
            SubjectOfChangeSet.OnNext(changeSet);
        }

        private static void Remove(ChangeSet<TModel, TId> changeSet, TId id)
        {
            changeSet.Add(
                new Change<TModel, TId>(
                    ChangeReason.Remove,
                    id,
                    default,
                    Optional<TModel>.None
                )
            );
        }

        private static void AddOrUpdate(ChangeSet<TModel, TId> changeSet, TModel model)
        {
            changeSet.Add(
                new Change<TModel, TId>(
                    ChangeReason.Add,
                    model.Id,
                    model,
                    Optional<TModel>.None
                )
            );
        }

        public IDisposable Subscribe(IObserver<ChangeSet<TModel, TId>> observer)
            => SubjectOfChangeSet.Subscribe(observer);
    }
}