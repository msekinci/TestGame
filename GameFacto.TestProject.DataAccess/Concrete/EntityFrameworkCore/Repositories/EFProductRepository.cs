using GameFacto.TestProject.DataAccess.Concrete.EntityFrameworkCore.Context;
using GameFacto.TestProject.DataAccess.Interfaces;
using GameFacto.TestProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameFacto.TestProject.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EFProductRepository : EFGenericRepository<Product>, IProductDAL
    {
        private readonly TestProjectContext _context;
        public EFProductRepository(TestProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllByCategoryId(int categoryId)
        {
            List<int> categories = new List<int>();
            await GetChildCategoriesAsync(categoryId, categories);
            return await _context.Products.Where(x => x.IsActive && categories.Contains(x.CategoryId)).ToListAsync();
        }

        private async Task GetChildCategoriesAsync(int categoryId, List<int> categories)
        {
            var category = await _context.Categories.Where(x => x.Id == categoryId).Include(x => x.SubCategories).FirstOrDefaultAsync();
            if (category != null)
            {
                categories.Add(category.Id);
                if (category.SubCategories != null)
                {
                    foreach (var item in category.SubCategories)
                    {
                        await GetChildCategoriesAsync(item.Id, categories);
                    }
                }
            }
        }
    }
}
