using Blog.API.Models;
using Blog.API.Models.DTOs.User;
using System.Data.Common;

namespace Blog.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserResponseDTO>> GetAllUsersAsync();
        Task<UserResponseDTO> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task UpdatePasswordUserAsync(string senha, int id);
        Task UpdateBioUserAsync(string bio, int id);
        Task UpdateImageUserAsync(string image, int id);
        
    }
}
