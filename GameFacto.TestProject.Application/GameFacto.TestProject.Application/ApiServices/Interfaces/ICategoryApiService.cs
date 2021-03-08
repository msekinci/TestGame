using GameFacto.TestProject.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameFacto.TestProject.Application.ApiServices.Interfaces
{
    public interface ICategoryApiService
    {
        Task<List<CategoryList>> GetCategoriesMenuItems(int? categoryId);
    }
}
