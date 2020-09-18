using AutoMapper;
using Dal.Entities;
using Dal.Interfaces.Dal;
using Dal.Services.Base;
using Microsoft.Extensions.Logging;
using Shared.Interfaces.DataServices;
using Shared.Interfaces.DbServices;
using Shared.Models;

namespace Dal.Services
{
    public class ProductDbService : ConnectedDbServiceBase<ProductEntity, ProductModel, ProductModel, string>, IProductDbService
    {
        public ProductDbService(IProductDataService dataServiceBase, IContextFactory contextFactory, ILogger<ProductDbService> logger, IMapper mapper) : base(dataServiceBase, contextFactory, logger, mapper)
        {
        }
    }
}