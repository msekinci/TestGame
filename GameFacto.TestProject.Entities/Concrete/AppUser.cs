using Microsoft.AspNetCore.Identity;

namespace GameFacto.TestProject.Entities.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
