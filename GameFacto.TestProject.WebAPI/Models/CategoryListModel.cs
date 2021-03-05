using GameFacto.TestProject.Entities.Concrete;
using System.Collections.Generic;

namespace GameFacto.TestProject.WebAPI.Models
{
    public class CategoryListModel
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public List<Category> SubCategories { get; set; }
    }
}
