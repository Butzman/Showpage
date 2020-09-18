using Shared.Interfaces;

namespace Api.Dtos.Base
{
    public class DtoBase<TId>: IHaveAnId<TId>
    {
        public TId Id { get; }
    }
}