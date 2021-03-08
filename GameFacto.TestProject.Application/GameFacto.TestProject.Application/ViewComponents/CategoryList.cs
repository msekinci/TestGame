using GameFacto.TestProject.Application.ApiServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GameFacto.TestProject.Application.ViewComponents
{
    public class CategoryList : ViewComponent
    {
        private readonly ICategoryApiService _categoryApiService;
        public CategoryList(ICategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }
        public IViewComponentResult Invoke(int? categoryId, string categoryName)
        {
            //Cannot be async method in ViewComponant
            var categoryList = _categoryApiService.GetCategoriesMenuItems(categoryId).Result;
            ViewBag.CategoryId = categoryId;

            if (categoryId != null)
            {
                ViewBag.CategoryName = categoryList.Where(x => x.Id == categoryId).First().Name;
            }
            
            return View(categoryList);
        }
    }
}
