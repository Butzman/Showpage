using AutoMapper;
using Backend_Shared.Models;
using Shared.Dtos;

namespace Api
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ProductDto, ProductModel>();
            CreateMap<ProductModel, ProductDto>();
        }
    }
}