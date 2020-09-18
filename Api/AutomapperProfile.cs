using Api.Dtos;
using AutoMapper;
using Shared.Models;

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