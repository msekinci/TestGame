using GameFacto.TestProject.Application.ApiServices.Interfaces;
using GameFacto.TestProject.Application.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameFacto.TestProject.Application.ApiServices.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IHttpContextAccessor _accessor;
        public AuthManager(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public async Task<bool> SignIn(AppUserLogin userLogin)
        {
            var jsonData = JsonConvert.SerializeObject(userLogin);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync("http://localhost:54603/api/auth/signin", stringContent);

            if (response.IsSuccessStatusCode)
            {
                var token = JsonConvert.DeserializeObject<AccessToken>(await response.Content.ReadAsStringAsync());
                _accessor.HttpContext.Session.SetString("token", token.Token);
                return true;
            }

            return false;
        }

        public void SignOut() 
        {
            _accessor.HttpContext.Session.Remove("token");
        }
    }
}
