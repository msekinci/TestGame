using System.ComponentModel.DataAnnotations;

namespace GameFacto.TestProject.WebAPI.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "User cannot be null")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password cannot be null")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPassword cannot be null")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Please confirm password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Name cannot be null")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname cannot be null")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Email cannot be null")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
