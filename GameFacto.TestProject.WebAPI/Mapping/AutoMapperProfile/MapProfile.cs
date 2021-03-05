using AutoMapper;
using GameFacto.TestProject.Entities.Concrete;
using GameFacto.TestProject.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFacto.TestProject.WebAPI.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductAddModel, Product>();
            CreateMap<Product, ProductAddModel>();
        }
    }
}
