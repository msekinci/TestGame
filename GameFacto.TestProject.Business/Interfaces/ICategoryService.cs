using GameFacto.TestProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameFacto.TestProject.Business.Interfaces
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task<List<Category>> GetAllWithSubCategoriesAsync(int? parentCategoryId);
    }
}
