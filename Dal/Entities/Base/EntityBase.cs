using Shared.Interfaces;

namespace Dal.Entities.Base
{
    public class EntityBase<TId>: IHaveAnId<TId>
    {
        public TId Id { get; }
    }
}