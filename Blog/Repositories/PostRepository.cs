using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs.Post;
using Blog.API.Models.DTOs.User;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class PostRepository
    {
        public readonly SqlConnection _connection;

        public PostRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }
        public async Task<List<PostResponseDTO>> GetAllPostsAsync()
        {
            var sql = "SELECT Title, Summary, Body, Slug FROM [Post]";

            var posts = (await _connection.QueryAsync<PostResponseDTO>(sql)).ToList();

            return posts;
        }

        //public async Task<PostResponseDTO> GetPostByIdAsync(int id)
        //{
        //    var sql = "SELECT Name, Email, Bio, Image, Slug FROM [Post]";
        //    var post = await _connection.QueryFirstOrDefaultAsync<PostResponseDTO>(sql, new { Id = id });
        //    return post;
        //}
        //public async Task CreatePostAsync(Post post)
        //{
        //    var sql = "INSERT INTO [Post] (Name, Email, PasswordHash, Bio, Image, Slug) VALUES (@Name, @Email, @PasswordHash, @Bio, @Image, @Slug)";

        //    await _connection.ExecuteAsync(sql, new { user.Name, user.Email, user.PasswordHash, user.Bio, user.Image, user.Slug });
        //}

        //public async Task DeletePostAsync(int id)
        //{
        //    var sql = "DELETE FROM [Post] WHERE Id = @Id";
        //    await _connection.ExecuteAsync(sql, new { Id = id });
        //}

        //public async Task UpdatePasswordUserAsync(string senha, int id)
        //{
        //    var sql = "UPDATE [Post] SET PasswordHash = @PasswordHash WHERE Id = @Id";
        //    await _connection.ExecuteAsync(sql, new { PasswordHash = senha, Id = id });
        //}
        //public async Task UpdateBioUserAsync(string bio, int id)
        //{
        //    var sql = "UPDATE [Post] SET Bio = @Bio WHERE Id = @Id";
        //    await _connection.ExecuteAsync(sql, new { Bio = bio, Id = id });
        //}
        //public async Task UpdateImageUserAsync(string image, int id)
        //{
        //    var sql = "UPDATE [User] SET Image = @Image WHERE Id = @Id";
        //    await _connection.ExecuteAsync(sql, new { Image = image, Id = id });
        //}

        public async Task<List<PostResponseDTO>> GetPostsByTagAsync(string tag)
        {
            var sql = @"
                SELECT p.Title, p.Summary, p.Body, p.Slug
                FROM [Post] p
                INNER JOIN PostTag pt ON p.Id = pt.PostId
                INNER JOIN [Tag] t ON pt.TagId = t.Id
                WHERE t.Slug = @TagSlug";
            var posts = (await _connection.QueryAsync<PostResponseDTO>(sql, new { Tag = tag })).ToList();
            return posts;
        }
    }
}
