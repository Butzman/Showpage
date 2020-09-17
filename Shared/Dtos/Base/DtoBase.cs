using Shared.Interfaces;

namespace Shared.Dtos.Base
{
    public class DtoBase<TId>: IHaveAnId<TId>
    {
        public TId Id { get; }
    }
}