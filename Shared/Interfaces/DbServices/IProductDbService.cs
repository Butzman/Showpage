using Shared.Interfaces.DbServices.Base;
using Shared.Models;

namespace Shared.Interfaces.DbServices
{
    public interface IProductDbService : IConnectedDbServiceBase<ProductModel, ProductModel, string>
    {
    }
}