using GameFacto.TestProject.Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace GameFacto.TestProject.WebAPI.Models
{
    public class ProductAddModel
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
    }
}
