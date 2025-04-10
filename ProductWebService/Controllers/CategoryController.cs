using Microsoft.AspNetCore.Mvc;
using ProductWebService.Model.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get()
        {
           var data = categoryService.GetCategory();
            return Ok(data);
        }

     

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] CategoryDto categordto)
        {
            categoryService.AddCategory(categordto);
            return Ok();
        }

      
 
    }
}
