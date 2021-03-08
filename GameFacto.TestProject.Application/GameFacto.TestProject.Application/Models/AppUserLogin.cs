using System.ComponentModel.DataAnnotations;

namespace GameFacto.TestProject.Application.Models
{
    public class AppUserLogin
    {
        [Required(ErrorMessage ="Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
