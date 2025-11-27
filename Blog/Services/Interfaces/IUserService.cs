using Blog.API.Models;
using Blog.API.Models.DTOs.User;

namespace Blog.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponseDTO>> GetAllUsersAsync();
        Task<UserResponseDTO> GetUserByIdAsync(int id);
        Task CreateUserAsync(UserRequestDTO user);
        Task DeleteUserAsync(int id);
        Task UpdatePasswordUserAsync(string senha, int id);
        Task UpdateBioUserAsync(string bio, int id);
        Task UpdateImageUserAsync(string image, int id);
      
    }
}
