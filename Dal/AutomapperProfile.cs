using AutoMapper;
using Dal.Entities;
using Shared.Models;

namespace Dal
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ProductEntity, ProductModel>();
            CreateMap<ProductModel, ProductEntity>();
        }
    }
}