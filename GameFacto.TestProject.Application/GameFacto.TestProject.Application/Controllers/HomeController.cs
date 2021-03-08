using GameFacto.TestProject.Application.ApiServices.Interfaces;
using GameFacto.TestProject.Application.CustomFilters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameFacto.TestProject.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        [JwtAuthorize(Roles = "product_view")]
        public async Task<IActionResult> Index(int? categoryId)
        {
            ViewBag.CategoryId = categoryId;
            var products = await _productService.GetAll(categoryId);
            return View(products);
        }
    }
}
