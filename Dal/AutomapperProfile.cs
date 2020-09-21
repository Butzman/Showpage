using AutoMapper;
using Backend_Shared.Models;
using Dal.Entities;

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