using System.Linq;
using AutoMapper;
using Backend_Shared.Models;
using Dal.Entities;
using Shared.Dtos;

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
                    cartModel => cartModel.Products,
                    memberOptions => memberOptions.MapFrom(cartEntity => cartEntity.Products)
                );

            CreateMap<CartModel, CartEntity>()
                .ForMember(
                    productEntity => productEntity.Products,
                    memberOptions => memberOptions.MapFrom(cartModel => cartModel.Products)
                );

            CreateMap<ProductToCartModel, ProductToCartEntity>()
                .ForMember(
                    entity => entity.Amount,
                    memberOptions => memberOptions.MapFrom(model => model.Amount)
                )
                .ForMember(
                    entity => entity.ProductId,
                    memberOptions => memberOptions.MapFrom(model => model.ProductId)
                );
            CreateMap<ProductToCartEntity, ProductToCartModel>()
                .ForMember(
                    model => model.Amount,
                    memberOptions => memberOptions.MapFrom(entity => entity.Amount)
                )
                .ForMember(
                    model => model.ProductId,
                    memberOptions => memberOptions.MapFrom(entity => entity.ProductId)
                );
        }
    }
}