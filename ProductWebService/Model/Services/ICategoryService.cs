using ProductWebService.Infrastructure.Context;
using ProductWebService.Model.Entity;

namespace ProductWebService.Model.Services
{
    public interface ICategoryService
    {
        List<CategoryDto> GetCategory();
        void AddCategory(CategoryDto category);
    }

    class CategoryService : ICategoryService
    {
        private readonly ProductDatabaseContext databaseContext;

        public CategoryService(ProductDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public void AddCategory(CategoryDto category)
        {
            Category categ = new Category
            {
                 Name= category.Name,
                 Description= category.Description,
            };
            databaseContext.Categories.Add(categ);
            databaseContext.SaveChanges();
        }

        public List<CategoryDto> GetCategory()
        {
            var category = databaseContext.Categories
                          .OrderBy(c => c.Name)
                          .Select(p => new CategoryDto
                          {
                              Name=p.Name,
                              Description=p.Description
                          }).ToList();
            return category;
        }
    }

    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
