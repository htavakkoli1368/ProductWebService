using Microsoft.AspNetCore.Mvc;
using ProductWebService.Model.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            var data = productService.GetProductsList();
            return Ok(data);

        }
        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var product = productService.GetProduct(id);
            return Ok(product); 
        }

      
    }
}
