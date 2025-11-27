using Blog.API.Models;
using Blog.API.Models.DTOs.Role;
using Blog.API.Repositories;

namespace Blog.API.Services.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleResponseDTO>> GetAllRolesAsync();
        Task<RoleResponseDTO> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(RoleRequestDTO role);
        Task DeleteRoleAsync(int id);
        Task UpdateRoleAsync(RoleRequestDTO role, int id);
      
    }
}
