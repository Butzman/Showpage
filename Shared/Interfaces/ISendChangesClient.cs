using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface ISendChangesClient<TDto, TId>
        where TDto : IHaveAnId<TId>
    {
        Task SendChanges(IReadOnlyList<TDto> addedOrUpdated, IReadOnlyList<TId> deletedIds);
        Task SendAll(IReadOnlyList<TDto> allModels);
    }
}