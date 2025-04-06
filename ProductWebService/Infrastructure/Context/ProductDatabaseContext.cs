using Microsoft.EntityFrameworkCore;
using ProductWebService.Model.Entity;

namespace ProductWebService.Infrastructure.Context
{
    public class ProductDatabaseContext:DbContext
    {
        public ProductDatabaseContext(DbContextOptions<ProductDatabaseContext> options):base(options)
        {
                
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
