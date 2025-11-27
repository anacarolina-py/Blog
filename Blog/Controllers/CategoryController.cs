using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs.Category;
using Blog.API.Services;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
       
        private CategoryService _categoryService;
        public CategoryController(CategoryService service) //injeção de dependência
        {
            _categoryService = service;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("API is running.");

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CategoryResponseDTO>>> GetAllCategories()
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<CategoryResponseDTO>> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateCategory(CategoryRequestDTO category)
        {
            try
            {
                await _categoryService.CreateCategoryAsync(category);

                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryService.DeleteCategoryAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> UpdateCategory(int id, [FromBody] CategoryRequestDTO category)
        {
            try
            {
                await _categoryService.UpdateCategoryAsync(category, id);
                return Ok($"Update category with id: {id}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



















        }
}
