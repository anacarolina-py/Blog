using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs.Tag;
using Blog.API.Models.DTOs.User;
using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace Blog.API.Repositories
{
    public class UserRepository
    {
        public readonly SqlConnection _connection;

        public UserRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }
        public async Task<List<UserResponseDTO>> GetAllUsersAsync()
        {
            var sql = "SELECT Name, Email, Bio, Image, Slug FROM [User]";

            var users = (await _connection.QueryAsync<UserResponseDTO>(sql)).ToList();

            return users;
        }
        public async Task<UserResponseDTO> GetUserByIdAsync(int id)
        {
            var sql = "SELECT Name, Email, Bio, Image, Slug FROM [User]";
            var user = await _connection.QueryFirstOrDefaultAsync<UserResponseDTO>(sql, new { Id = id });
            return user;
        }
        public async Task CreateUserAsync(User user)
        {
            var sql = "INSERT INTO [User] (Name, Email, PasswordHash, Bio, Image, Slug) VALUES (@Name, @Email, @PasswordHash, @Bio, @Image, @Slug)";

            await _connection.ExecuteAsync(sql, new { user.Name, user.Email, user.PasswordHash, user.Bio, user.Image, user.Slug });
        }

        public async Task DeleteUserAsync(int id)
        {
            var sql = "DELETE FROM [User] WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task UpdatePasswordUserAsync(string senha, int id)
        {
            var sql = "UPDATE [User] SET PasswordHash = @PasswordHash WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { PasswordHash = senha, Id = id});
        }
        public async Task UpdateBioUserAsync(string bio, int id)
        {
            var sql = "UPDATE [User] SET Bio = @Bio WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { Bio = bio, Id = id});
        }
        public async Task UpdateImageUserAsync(string image, int id)
        {
            var sql = "UPDATE [User] SET Image = @Image WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { Image = image, Id = id});
        }
        public async Task<List<User>> GetAllUserRoles()
        {
            
            var sql = @"SELECT * FROM [User] u 
                    JOIN [UserRole] ur ON u.Id = ur.UserId 
                    JOIN [Role] r ON r.Id = ur.RoleId";

            IEnumerable<User> userRoles = new List<User>();

            await _connection.QueryAsync<User, Role, User>

               (sql,
                (user, role) =>
                {
                    user.Roles.Add(role);
                    return user;
                },

             splitOn: "Id");

            return userRoles.ToList();
            
        }
    }
}
