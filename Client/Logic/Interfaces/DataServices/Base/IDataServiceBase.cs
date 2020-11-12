using System;
using DynamicData;
using Shared.Interfaces;

namespace BlazorClient.Logic.Interfaces.DataServices.Base
{
    public interface IDataServiceBase<TDto, TId>
        where TDto : IHaveAnId<TId>
    {
        SourceCache<TDto, TId> ModelCache { get; }
        IObservable<TId> DeletedDtos { get; }
        IObservable<TDto> AddedOrUpdatedDtos { get; }
    }
}