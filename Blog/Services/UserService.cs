using Blog.API.Models;
using Blog.API.Models.DTOs.Tag;
using Blog.API.Models.DTOs.User;
using Blog.API.Repositories;
using Blog.API.Repositories.Interfaces;

namespace Blog.API.Services
{
    public class UserService
    {
        private UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<UserResponseDTO>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }
        public async Task<UserResponseDTO> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }
        public async Task CreateUserAsync(UserRequestDTO user)
        {
            var newUser = new User(user.Name, user.Email, user.PasswordHash, user.Bio, user.Image,
                                   user.Name.ToLower().Replace(" ", "-"));

            await _userRepository.CreateUserAsync(newUser);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task UpdatePasswordUserAsync(string senha, int id)
        {
          
            await _userRepository.UpdatePasswordUserAsync(senha, id);
        }
        public async Task UpdateBioUserAsync(string bio, int id)
        {
          
            await _userRepository.UpdateBioUserAsync(bio, id);
        }
        public async Task UpdateImageUserAsync(string image, int id)
        {
          
            await _userRepository.UpdateImageUserAsync(image, id);
        }
    }
}
