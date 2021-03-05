using GameFacto.TestProject.Business.Interfaces;
using GameFacto.TestProject.DataAccess.Interfaces;
using GameFacto.TestProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameFacto.TestProject.Business.Containers.MicrosoftIoC
{
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;
        public CategoryManager(IGenericDAL<Category> genericDAL, ICategoryDAL categoryDAL) : base(genericDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public async Task<List<Category>> GetAllWithSubCategoriesAsync(int? parentCommentId)
        {
            return await _categoryDAL.GetAllWithSubCategoriesAsync(parentCommentId);
        }
    }
}
