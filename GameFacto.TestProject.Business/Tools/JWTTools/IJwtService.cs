using GameFacto.TestProject.Entities.Concrete;

namespace GameFacto.TestProject.Business.Tools.JWTTools
{
    public interface IJwtService
    {
        JwtToken GenerateJwt(AppUser user);
    }
}
