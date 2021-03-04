using GameFacto.TestProject.WebAPI.Context;

namespace GameFacto.TestProject.WebAPI.Tools
{
    public interface IJwtService
    {
        JwtToken GenerateJwt(AppUser user);
    }
}
