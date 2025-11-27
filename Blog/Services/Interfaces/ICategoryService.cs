using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Models.DTOs.Category;
using Blog.API.Repositories;
using Blog.API.Repositories.Interfaces;

namespace Blog.API.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseDTO>> GetAllCategoriesAsync();
        Task<CategoryResponseDTO> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(CategoryRequestDTO category);
        Task DeleteCategoryAsync(int id);
        Task UpdateCategoryAsync(CategoryRequestDTO category, int id);
      

    }
}
