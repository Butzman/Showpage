using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using DynamicData;
using DynamicData.Kernel;
using Shared.Extensions;
using Shared.Interfaces;
using Shared.Interfaces.DataServices;

namespace Shared.Services.DataServices.Base
{
    public class DataServiceBase<TModel, TId> : DisposableBase, IDataServiceBase<TModel, TId>
        where TModel : IHaveAnId<TId>
    {
        public IObservable<ChangeSet<TModel, TId>> ObservableOfChangeSet
            => SubjectOfChangeSet.AsObservable();

        public IObservable<IList<TModel>> ObservableOfAddOrUpdates
            => SubjectOfAddOrUpdates.AsObservable();

        public IObservable<IList<TModel>> ObservableOfRemoves
            => SubjectOfRemoves.AsObservable();

        protected readonly Subject<ChangeSet<TModel, TId>> SubjectOfChangeSet;
        protected readonly Subject<IList<TModel>> SubjectOfAddOrUpdates;
        protected readonly Subject<IList<TModel>> SubjectOfRemoves;

        public DataServiceBase()
        {
            SubjectOfChangeSet = new Subject<ChangeSet<TModel, TId>>().DisposeWith(this);
            SubjectOfAddOrUpdates = new Subject<IList<TModel>>().DisposeWith(this);
            SubjectOfRemoves = new Subject<IList<TModel>>().DisposeWith(this);

            ObservableOfChangeSet
                .Do(changeSet =>
                {
                    var addOrUpdates = new List<TModel>();
                    var removes = new List<TModel>();
                    foreach (var change in changeSet)
                    {
                        switch (change.Reason)
                        {
                            case ChangeReason.Add:
                            case ChangeReason.Update:
                                addOrUpdates.Add(change.Current);
                                break;
                            case ChangeReason.Remove:
                                removes.Add(change.Current);
                                break;
                            case ChangeReason.Refresh:
                                break;
                            case ChangeReason.Moved:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                    SubjectOfRemoves.OnNext(removes);
                    SubjectOfAddOrUpdates.OnNext(addOrUpdates);
                })
                .Subscribe()
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
    }
}