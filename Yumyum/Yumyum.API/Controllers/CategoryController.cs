using Microsoft.AspNetCore.Mvc;
using Yumyum.Core.DTOs;
using Yumyum.Infrastructure.Services.Categories;

namespace Yumyum.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto input)
        {
            var category = await _categoryService.Create(input);
            return Ok(category);

        }
        [HttpPut]
        public async Task<IActionResult> Update (UpdateCategoryDto input)
        {
            var category = await _categoryService.Update(input);
            return Ok(category);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string? serachKey)
        {
            var category = await _categoryService.GetAll(serachKey);
            return Ok(category);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           await _categoryService.Delete(id);
            return Ok();
        }

    }
}
