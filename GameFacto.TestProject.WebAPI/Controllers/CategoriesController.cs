using AutoMapper;
using GameFacto.TestProject.Business.Interfaces;
using GameFacto.TestProject.Entities.Concrete;
using GameFacto.TestProject.WebAPI.CustomFilters;
using GameFacto.TestProject.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameFacto.TestProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<CategoryListModel>>(await _categoryService.GetAllWithSubCategoriesAsync(null)));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<CategoryListModel>(await _categoryService.FindByIdAsyc(id)));
        }

        [HttpGet("[action]/{id:int?}")]
        public async Task<IActionResult> GetCategories(int? id)
        {
            var categories = await _categoryService.GetSelectedCategoryChildren(id);
            return Ok(categories);
        }

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> Add(CategoryAddModel categoryAddModel)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryAddModel));
            return Created("", categoryAddModel);
        }

        [HttpPut("{id}")]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> Update(int id, CategoryUpdateModel categoryUpdateModel)
        {
            if (id != categoryUpdateModel.Id)
            {
                return BadRequest("Invalid ID");
            }
            await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryUpdateModel));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.RemoveAsync(await _categoryService.FindByIdAsyc(id));
            return NoContent();
        }
    }
}
