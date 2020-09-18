using Shared.Interfaces;

namespace Shared.Models.Base
{
    public class ModelBase<TId>:IHaveAnId<TId>
    {
        public TId Id { get; set; }
    }
}