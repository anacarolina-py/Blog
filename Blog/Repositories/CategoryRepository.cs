using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs.Category;
using Blog.API.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class CategoryRepository :ICategoryRepository
    {
        public readonly SqlConnection _connection;

        public CategoryRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }
        public async Task <List<CategoryResponseDTO>> GetAllCategoriesAsync()
        {
            var sql = "SELECT Name, Slug FROM Category";

                var categories = (await _connection.QueryAsync<CategoryResponseDTO>(sql)).ToList();

                return categories; 
        }

        public async Task<CategoryResponseDTO> GetCategoryByIdAsync(int id)
        {
            var sql = "SELECT Name, Slug FROM Category WHERE Id = @Id";
                var category = await _connection.QueryFirstOrDefaultAsync<CategoryResponseDTO>(sql, new { Id = id });
                return category;
        }
        public async Task CreateCategoryAsync(Category category)
        {
            var sql = "INSERT INTO Category (Name, Slug) VALUES (@Name, @Slug)";

                await _connection.ExecuteAsync(sql, new { category.Name, category.Slug });
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var sql = "DELETE FROM Category WHERE Id = @Id";
                await _connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            var sql = "UPDATE Category SET Name = @Name, Slug = @Slug WHERE Id = @Id";
                await _connection.ExecuteAsync(sql, new { category.Name, category.Slug, category.Id });
        }


    }
}
