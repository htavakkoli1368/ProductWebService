namespace ProductWebService.Model.Entity
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }

    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int Price { get; set; }
        public Guid CategoryId { get; set; }

        public  Category? Category { get; set; }

    }
}
