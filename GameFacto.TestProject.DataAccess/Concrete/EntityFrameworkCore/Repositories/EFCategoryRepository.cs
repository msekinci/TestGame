using GameFacto.TestProject.DataAccess.Concrete.EntityFrameworkCore.Context;
using GameFacto.TestProject.DataAccess.Interfaces;
using GameFacto.TestProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameFacto.TestProject.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EFCategoryRepository : EFGenericRepository<Category>, ICategoryDAL
    {
        private readonly TestProjectContext _context;
        public EFCategoryRepository(TestProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllWithSubCategoriesAsync(int? parentCategoryId)
        {
            List<Category> result = new List<Category>();
            await GetCategories(parentCategoryId, result);
            return result;
        }

        private async Task GetCategories(int? parentCategoryId, List<Category> result)
        {
            var categories = await _context.Categories.Where(x => x.ParentCategoryId == parentCategoryId).ToListAsync();
            if (categories.Count > 0)
            {
                foreach (var category in categories)
                {
                    if (category.SubCategories == null)
                    {
                        category.SubCategories = new List<Category>();
                    }

                    await GetCategories(category.Id, category.SubCategories);

                    if (!result.Contains(category))
                    {
                        result.Add(category);
                    }
                }
            }
        }
    }
}
