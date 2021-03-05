using AutoMapper;
using Boxed.AspNetCore;
using GameFacto.TestProject.Business.Interfaces;
using GameFacto.TestProject.Entities.Concrete;
using GameFacto.TestProject.WebAPI.CustomFilters;
using GameFacto.TestProject.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameFacto.TestProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "product_view")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{name}/{id}")]
        [Authorize(Roles = "product_view")]
        public async Task<IActionResult> Get(int? id, string name)
        {
            if (id == null || await _productService.FindByIdAsyc((int)id) == null)
            {
                return NotFound();
            }

            var product = await _productService.FindByIdAsyc((int)id);
            string friendlyName = FriendlyUrlHelper.GetFriendlyTitle(product.Name);

            if (!string.Equals(friendlyName, name, StringComparison.Ordinal))
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> Add([FromForm] ProductAddModel productAddModel)
        {
            var uploadModel = await UploadFileAsync(productAddModel.Image, "image/jpeg");
            if (uploadModel.UploadState == Enums.UploadState.Success)
            {
                productAddModel.ImageUrl = uploadModel.NewName;
                await _productService.AddAsync(_mapper.Map<Product>(productAddModel));
                return Created("", productAddModel);
            }
            else if (uploadModel.UploadState == Enums.UploadState.NotExist)
            {
                await _productService.AddAsync(_mapper.Map<Product>(productAddModel));
                return Created("", productAddModel);
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        [HttpPut("{id}")]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> Update(int id, [FromForm] ProductUpdateModel productUpdateModel)
        {
            if (id != productUpdateModel.Id)
            {
                return BadRequest("Invalid ID");
            }

            var uploadModel = await UploadFileAsync(productUpdateModel.Image, "image/jpeg");
            if (uploadModel.UploadState == Enums.UploadState.Success)
            {
                var updatedProduct = await _productService.FindByIdAsyc(productUpdateModel.Id);
                updatedProduct.Name = productUpdateModel.Name;
                updatedProduct.Description = productUpdateModel.Description;
                updatedProduct.IsActive = productUpdateModel.IsActive;
                updatedProduct.Price = productUpdateModel.Price;
                updatedProduct.ImageUrl = uploadModel.NewName;
                await _productService.UpdateAsync(updatedProduct);
                return NoContent();
            }
            else if (uploadModel.UploadState == Enums.UploadState.NotExist)
            {
                var updatedProduct = await _productService.FindByIdAsyc(productUpdateModel.Id);
                updatedProduct.Name = productUpdateModel.Name;
                updatedProduct.Description = productUpdateModel.Description;
                updatedProduct.IsActive = productUpdateModel.IsActive;
                updatedProduct.Price = productUpdateModel.Price;
                await _productService.UpdateAsync(updatedProduct);
                return NoContent();
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.RemoveAsync(await _productService.FindByIdAsyc(id));
            return NoContent();
        }

        [HttpGet("[action]/{id}")]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> GetAllByCategoryId(int id)
        {
            return Ok(_mapper.Map<List<Product>>(await _productService.GetAllByCategoryId(id)));
        }
    }
}
