using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebServer1.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IDataService _dataService;

        public ProductsController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product =
                _dataService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("category/{id}")]
        public IActionResult GetProductsByCategory(int id)
        {
            var product =
                _dataService.GetProductsByCategoryId(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("name/{substring}")]
        public IActionResult GetProductsBySubstring(string substring)
        {
            var product =
                _dataService.GetProductsThatContainSubstring(substring);
            if (product.Count == 0)
            {
                return NotFound();
            }
            return Ok(product);
        }

    }
}
