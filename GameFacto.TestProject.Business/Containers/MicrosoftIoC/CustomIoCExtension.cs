using GameFacto.TestProject.Business.Tools.JWTTools;
using GameFacto.TestProject.DataAccess.Concrete.EntityFrameworkCore.Context;
using Microsoft.Extensions.DependencyInjection;

namespace GameFacto.TestProject.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtManager>();
            services.AddDbContext<TestProjectContext>();
        }
    }
}
