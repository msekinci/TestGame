using GameFacto.TestProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameFacto.TestProject.DataAccess.Interfaces
{
    public interface ICategoryDAL : IGenericDAL<Category>
    {
        Task<List<Category>> GetAllWithSubCategoriesAsync(int? parentCategoryId);
        Task<List<Category>> GetSelectedCategoryChildren(int? id);
    }
}
