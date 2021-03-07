namespace GameFacto.TestProject.Application.Models
{
    public class ProductList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
    }
}
