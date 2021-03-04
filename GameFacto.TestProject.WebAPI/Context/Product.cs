namespace GameFacto.TestProject.WebAPI.Context
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public bool isActive { get; set; }
        public string Description { get; set; }
    }
}
