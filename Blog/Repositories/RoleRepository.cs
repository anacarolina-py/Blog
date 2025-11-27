using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs.Category;
using Blog.API.Models.DTOs.Role;
using Blog.API.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public readonly SqlConnection _connection;

        public RoleRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }
        public async Task<List<RoleResponseDTO>> GetAllRolesAsync()
        {
            var sql = "SELECT Name, Slug FROM Role";

            var roles = (await _connection.QueryAsync<RoleResponseDTO>(sql)).ToList();

            return roles;
        }
        public async Task<RoleResponseDTO> GetRoleByIdAsync(int id)
        {
            var sql = "SELECT Name, Slug FROM Role WHERE Id = @Id";
            var role = await _connection.QueryFirstOrDefaultAsync<RoleResponseDTO>(sql, new { Id = id });
            return role;
        }
        public async Task CreateRoleAsync(Role role)
        {
            var sql = "INSERT INTO Role (Name, Slug) VALUES (@Name, @Slug)";

            await _connection.ExecuteAsync(sql, new { role.Name, role.Slug });
        }

        public async Task DeleteRoleAsync(int id)
        {
            var sql = "DELETE FROM Role WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task UpdateRoleAsync(Role role)
        {
            var sql = "UPDATE Role SET Name = @Name, Slug = @Slug WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { role.Name, role.Slug, role.Id });
        }
    }
}
