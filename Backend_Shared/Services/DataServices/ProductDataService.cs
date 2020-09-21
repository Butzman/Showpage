using Backend_Shared.Interfaces.DataServices;
using Backend_Shared.Services.DataServices.Base;
using Shared.Models;

namespace Backend_Shared.Services.DataServices
{
    public class ProductDataService: DataServiceBase<ProductModel,string>, IProductDataService
    {
            
    }
}