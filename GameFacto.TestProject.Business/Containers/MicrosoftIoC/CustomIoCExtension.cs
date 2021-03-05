using GameFacto.TestProject.Business.Interfaces;
using GameFacto.TestProject.Business.Tools.JWTTools;
using GameFacto.TestProject.DataAccess.Concrete.EntityFrameworkCore.Context;
using GameFacto.TestProject.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using GameFacto.TestProject.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GameFacto.TestProject.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtManager>();

            services.AddScoped(typeof(IGenericDAL<>), typeof(EFGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));


            services.AddScoped<IProductDAL, EFProductRepository>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<ICategoryDAL, EFCategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<IJwtService, JwtManager>();
            services.AddDbContext<TestProjectContext>();
        }
    }
}
