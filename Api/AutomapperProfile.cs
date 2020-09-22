using AutoMapper;
using Backend_Shared.Models;
using Dal.Entities;
using Shared.Dtos;

namespace Api
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ProductDto, ProductModel>();
            CreateMap<ProductModel, ProductDto>();

            CreateMap<CartDto, CartModel>();
            CreateMap<CartModel, CartDto>();
        }
    }
}