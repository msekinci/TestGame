using GameFacto.TestProject.Business.StringInfos;
using GameFacto.TestProject.Business.Tools.JWTTools;
using GameFacto.TestProject.Entities.Concrete;
using GameFacto.TestProject.WebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using static GameFacto.TestProject.Business.StringInfos.Enums;

namespace GameFacto.TestProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtService _jwtService;
        public AuthController(IJwtService jwtService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn([FromBody] SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                var identityResult = await _signInManager.PasswordSignInAsync(signInModel.UserName, signInModel.Password, false, true);

                if (identityResult.IsLockedOut)
                {
                    return Forbid("Your account is locked for 5 minutes.");
                }
                if (identityResult.Succeeded)
                {
                    var userResponse = _userManager.FindByNameAsync(signInModel.UserName);
                    return Created("", _jwtService.GenerateJwt(userResponse.Result));
                }
                else
                {
                    return Forbid("Please check your username or password");
                }
            }
            return BadRequest("An error occured.");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Email = signUpModel.Email,
                    Name = signUpModel.Name,
                    Surname = signUpModel.Surname,
                    UserName = signUpModel.UserName
                };

                var result = await _userManager.CreateAsync(user, signUpModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.product_view.ToString());
                    return Created("", user);
                }
                else
                {
                    return BadRequest(result.Errors.ToList());
                }
            }
            else
            {
                return BadRequest("Not valid model");
            }
        }
    }
}
