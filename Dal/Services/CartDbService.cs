using System.Linq;
using AutoMapper;
using Backend_Shared.Interfaces.DataServices;
using Backend_Shared.Interfaces.DbServices;
using Backend_Shared.Models;
using Dal.Entities;
using Dal.Interfaces.Dal;
using Dal.Services.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dal.Services
{
    public class CartDbService : ConnectedDbServiceBase<CartEntity, CartModel, CartModel, string>, ICartDbService
    {
        public CartDbService(ICartDataService cartDataService, IContextFactory contextFactory, ILogger<CartDbService> logger, IMapper mapper) : base(cartDataService, contextFactory, logger, mapper)
        {
        }

        protected override IQueryable<CartEntity> GetEntityQueryable(DbContext context)
        {
            return context.Set<CartEntity>().Include(x => x.Products);
        }
    }
}