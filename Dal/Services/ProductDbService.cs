﻿using AutoMapper;
using Backend_Shared.Interfaces.DataServices;
using Backend_Shared.Interfaces.DbServices;
using Backend_Shared.Models;
using Dal.Entities;
using Dal.Interfaces.Dal;
using Dal.Services.Base;
using Microsoft.Extensions.Logging;

namespace Dal.Services
{
    public class ProductDbService : ConnectedDbServiceBase<ProductEntity, ProductModel, ProductModel, string>, IProductDbService
    {
        public ProductDbService(IProductDataService dataServiceBase, IContextFactory contextFactory, ILogger<ProductDbService> logger, IMapper mapper) : base(dataServiceBase, contextFactory, logger, mapper)
        {
        }
    }
}