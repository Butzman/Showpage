using Backend_Shared.Interfaces.DataServices.Base;
using Backend_Shared.Models;

namespace Backend_Shared.Interfaces.DataServices
{
    public interface ICartDataService : IDataServiceBase<CartModel, string>
    {
    }
}