using Blog.API.Models;
using Blog.API.Models.DTOs.Category;
using Blog.API.Repositories;
using Blog.API.Services.Interfaces;

namespace Blog.API.Services
{
    public class CategoryService : ICategoryService
    {
        private CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task <List<CategoryResponseDTO>> GetAllCategoriesAsync()
        {  
            return await _categoryRepository.GetAllCategoriesAsync();
        }
        public async Task<CategoryResponseDTO> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetCategoryByIdAsync(id);
        }
        public async Task CreateCategoryAsync(CategoryRequestDTO category)
        {
            var newCategory = new Category(category.Name, 
                                           category.Name.ToLower().Replace(" ", "-") );

            await _categoryRepository.CreateCategoryAsync(newCategory);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
        }

        public async Task UpdateCategoryAsync(CategoryRequestDTO category, int id)
        {
            var newCategory = new Category(category.Name,
                                          category.Name.ToLower().Replace(" ", "-"));

            newCategory.SetId(id);
            await _categoryRepository.UpdateCategoryAsync(newCategory);
        }
    }
}
