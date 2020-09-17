using AutoMapper;
using Dal.Entities;
using Shared.Dtos;

namespace Dal
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ProductEntity, ProductDto>();
            CreateMap<ProductDto, ProductEntity>();
        }
    }
}