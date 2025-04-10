using Microsoft.AspNetCore.Mvc;
using ProductWebService.Model.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAdminController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductAdminController(IProductService productService)
        {
            this.productService = productService;
        }      

        // POST api/<ProductAdminController>
        [HttpPost]
        public IActionResult Post([FromBody] AddNewProductDto addNewProductDto)
        {
            productService.AddNewProduct(addNewProductDto);
            return Ok();
        }

       
    }
}
