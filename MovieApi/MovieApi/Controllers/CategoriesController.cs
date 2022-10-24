using CoreLayer.Dtos.CategoryDtos;
using CoreLayer.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _categoryService.GetAllCategory();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoryWithMovies(int id)
        {
            var result = await _categoryService.GetCategoryWithMovieById(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDto dto)
        {
            var result = await _categoryService.CreateCategory(dto);
            return Ok(result);
        }
    }
}
