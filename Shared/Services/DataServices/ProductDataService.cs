using Shared.Interfaces.DataServices;
using Shared.Models;
using Shared.Services.DataServices.Base;

namespace Shared.Services.DataServices
{
    public class ProductDataService: DataServiceBase<ProductModel,string>, IProductDataService
    {
            
    }
}