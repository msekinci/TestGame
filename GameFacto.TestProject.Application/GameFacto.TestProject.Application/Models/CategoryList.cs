namespace GameFacto.TestProject.Application.Models
{
    public class CategoryList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryList ParentCategory { get; set; }
    }
}
