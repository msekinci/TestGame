using System.Collections.Generic;

namespace GameFacto.TestProject.WebAPI.Models
{
    public class AppUserModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> Roles { get; set; }
    }
}
