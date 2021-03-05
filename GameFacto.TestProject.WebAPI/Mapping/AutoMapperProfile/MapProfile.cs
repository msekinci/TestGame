using AutoMapper;
using GameFacto.TestProject.Entities.Concrete;
using GameFacto.TestProject.WebAPI.Models;

namespace GameFacto.TestProject.WebAPI.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductAddModel, Product>();
            CreateMap<Product, ProductAddModel>();

            CreateMap<CategoryAddModel, Category>();
            CreateMap<CategoryUpdateModel, Category>();
            CreateMap<CategoryListModel, Category>();
            CreateMap<Category, CategoryAddModel>();
            CreateMap<Category, CategoryUpdateModel>();
            CreateMap<Category, CategoryListModel>();
        }
    }
}
