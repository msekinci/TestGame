using System.ComponentModel.DataAnnotations;

namespace GameFacto.TestProject.WebAPI.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "UserName cannot be null")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password cannot be null")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
