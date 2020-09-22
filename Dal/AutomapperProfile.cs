using System.Linq;
using AutoMapper;
using Backend_Shared.Models;
using Dal.Entities;

namespace Dal
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ProductEntity, ProductModel>();
            CreateMap<ProductModel, ProductEntity>();

            CreateMap<CartEntity, CartModel>()
                .ForMember(
                    cartModel => cartModel.ProductIds,
                    memberOptions => memberOptions.MapFrom(cartEntity => cartEntity.Products.Select(productToCart => productToCart.ProductId)
                    )
                );

            CreateMap<CartModel, CartEntity>()
                .ForMember(
                    productEntity => productEntity.Products,
                    memberOptions => memberOptions.MapFrom(cartModel => cartModel.ProductIds)
                );
        }
    }
}