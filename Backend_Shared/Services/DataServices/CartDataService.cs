using Backend_Shared.Interfaces.DataServices;
using Backend_Shared.Models;
using Backend_Shared.Services.DataServices.Base;

namespace Backend_Shared.Services.DataServices
{
    public class CartDataService: DataServiceBase<CartModel,string>, ICartDataService, ICartObservableOfChangeSet
    {
        
    }
}