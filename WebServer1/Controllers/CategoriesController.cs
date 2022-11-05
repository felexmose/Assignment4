using AutoMapper;
using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WebServer1.Models;

namespace WebServer1.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private IDataService _dataService;
        private readonly IMapper _mapper;
        public CategoriesController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories =
                _dataService.GetAllCategories();
            
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category =
                _dataService.GetCategoryById(id);
            
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryCreateModel model)
        {
            var category = _mapper.Map<Category>(model);

            _dataService.CreateCategory(category.Name, category.Description);            

            return Ok("created");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, CategoryCreateModel model)
        {
            var category = _mapper.Map<Category>(model);

            var updated = _dataService.UpdateCategory(id, category.Name, category.Description);
            if (updated == false)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var deleted = _dataService.DeleteCategory(id);
            if (deleted == false)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
