namespace Shared.Interfaces.DbServices.Base
{
    public interface IConnectedDbServiceBase<TModel, TSaveModel, TId> : IDbServiceBase<TModel, TSaveModel, TId>
    {
    }
}