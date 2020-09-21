﻿using AutoMapper;
using Shared.Dtos;
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