using GameFacto.TestProject.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GameFacto.TestProject.Entities.Concrete
{
    public class AppRole : IdentityRole<int>, IEntity
    {
    }
}
