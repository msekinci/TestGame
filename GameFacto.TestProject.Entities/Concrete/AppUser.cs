using GameFacto.TestProject.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GameFacto.TestProject.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
