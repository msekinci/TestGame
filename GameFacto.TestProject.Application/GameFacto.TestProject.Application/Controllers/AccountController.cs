using GameFacto.TestProject.Application.ApiServices.Interfaces;
using GameFacto.TestProject.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace GameFacto.TestProject.Application.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult SignIn()
        {
            string username = Request.Cookies["username"];
            string password = Request.Cookies["password"];
            string rememberme = Request.Cookies["rememberme"];

            AppUserLogin login = new AppUserLogin
            {
                UserName = username,
                Password = password,
                RememberMe = string.IsNullOrWhiteSpace(rememberme) ? false : bool.Parse(rememberme)
            };
            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                if (await _authService.SignIn(userLogin))
                {
                    if (userLogin.RememberMe)
                    {
                        CookieOptions cookie = new CookieOptions();
                        Response.Cookies.Append("username", userLogin.UserName, cookie);
                        Response.Cookies.Append("password", userLogin.Password, cookie);
                        Response.Cookies.Append("rememberme", userLogin.RememberMe.ToString(), cookie);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Please check your username and password");
                }
            }
            return View(userLogin);
        }
    }
}
