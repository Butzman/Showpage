using Shared.Interfaces;

namespace Backend_Shared.Models.Base
{
    public class ModelBase<TId>:IHaveAnId<TId>
    {
        public TId Id { get; set; }
    }
}