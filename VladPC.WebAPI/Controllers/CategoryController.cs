using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VladPC.BLL.DTO;
using VladPC.BLL.Interfaces;

namespace VladPC.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IProductService _productService;

        public CategoryController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetProductCategories()
        {
            var result = await Task.Run(() => _productService.GetCategoryDictionary());
            return Ok(result);
        }

        // GET: api/Category/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetProductCategory(int id)
        {
            var result = await Task.Run(() => _productService.GetCategory(id));
            return Ok(result);
        }
    }
}
