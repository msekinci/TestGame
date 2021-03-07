using GameFacto.TestProject.Application.Models;
using System.Threading.Tasks;

namespace GameFacto.TestProject.Application.ApiServices.Interfaces
{
    public interface IAuthService
    {
        Task<bool> SignIn(AppUserLogin userLogin);
        void SignOut();
    }
}
