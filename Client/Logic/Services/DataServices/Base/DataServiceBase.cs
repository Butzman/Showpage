using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using BlazorClient.Logic.Interfaces.DataServices.Base;
using DynamicData;
using Shared.Extensions;
using Shared.Interfaces;

namespace BlazorClient.Logic.Services.DataServices.Base
{
    public class DataServiceBase<TDto, TId> : DisposableBase, IDataServiceBase<TDto, TId>
        where TDto : IHaveAnId<TId>
    {
        public SourceCache<TDto, TId> ModelCache { get; }
            = new SourceCache<TDto, TId>(x => x.Id);

        public IObservable<TId> DeletedDtos
            => ModelCache
                .Connect()
                .WhereReasonsAre(ChangeReason.Remove)
                .Flatten()
                .Select(x => x.Key);

        public IObservable<TDto> AddedOrUpdatedDtos
            => ModelCache
                .Connect()
                .WhereReasonsAre(ChangeReason.Add, ChangeReason.Update)
                .Flatten()
                .Select(x => x.Current);

        public DataServiceBase()
        {
            ModelCache.DisposeWith(this);
        }
    }
}