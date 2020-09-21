using Backend_Shared.Interfaces.DbServices.Base;
using Shared.Models;

namespace Backend_Shared.Interfaces.DbServices
{
    public interface IProductDbService : IConnectedDbServiceBase<ProductModel, ProductModel, string>
    {
    }
}