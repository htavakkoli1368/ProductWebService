using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ProductWebService.Infrastructure.Context;
using ProductWebService.Model.Entity;

namespace ProductWebService.Model.Services
{
    public interface IProductService
    {
        List<ProductDto> GetProductsList();
        ProductDto GetProduct(Guid id);

        void AddNewProduct(AddNewProductDto addNewProductDto);
    }

    public class ProductService : IProductService
    {
        private readonly ProductDatabaseContext databaseContext;

        public ProductService(ProductDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void AddNewProduct(AddNewProductDto addNewProductDto)
        {
            var category = databaseContext.Categories.Find(addNewProductDto.CategoryId);
            if (category == null)
                throw new Exception("Category not found");

            Product product = new Product
            {
                Image=addNewProductDto.Image,
                Price=addNewProductDto.Price,
                Description=addNewProductDto.Description,
                Name =addNewProductDto.Name,
                Category=category
            };
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }

        public ProductDto GetProduct(Guid id)
        {
            var product = databaseContext.Products
                          .Include(p => p.Category)
                          .SingleOrDefault(c => c.Id==id);

            if (product == null)
                throw new Exception("product not found");
            var data = new ProductDto
            {
                Id = product.Id,
                Description = product.Description,
                Image = product.Image,
                Name = product.Name,
                Price = product.Price,
                ProductCategory = product.Category == null ? null : new ProductCategoryDto
                {
                    Category = product.Category.Name,
                    CategoryId = product.Category.Id
                }
            };
            return data;
        }

        public List<ProductDto> GetProductsList()
        {
            var products = databaseContext.Products
                           .Include(p=>p.Category)
                           .OrderByDescending(p => p.Id)
                           .Select(p => new ProductDto
                           {
                               Id = p.Id,
                               Description = p.Description,
                               Image= p.Image,
                               Name = p.Name,
                               Price = p.Price,
                               ProductCategory = new ProductCategoryDto
                               {
                                   Category = p.Category.Name,
                                   CategoryId=p.Category.Id
                               }
                           }).ToList();
            return products;
        }
    }

    public class ProductDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int Price { get; set; }

        public ProductCategoryDto ProductCategory { get; set; }

    }

    public class ProductCategoryDto
    {
        public Guid CategoryId { get; set; }

        public string Category { get; set; }
    }

    public class AddNewProductDto
    {
        
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int Price { get; set; }
        public Guid CategoryId { get; set; }

    }
}
