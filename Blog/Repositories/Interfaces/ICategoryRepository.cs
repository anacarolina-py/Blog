using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs.Category;
using System.Data.Common;

namespace Blog.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {

        Task<List<CategoryResponseDTO>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
        Task UpdateCategoryAsync(Category category);
        Task <CategoryResponseDTO> GetCategoryByIdAsync(int id);
       
    }
}
