using Blog.API.Models;
using Blog.API.Models.DTOs.Role;
using System.Data.Common;

namespace Blog.API.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<RoleResponseDTO>> GetAllRolesAsync();
        Task<RoleResponseDTO> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
        Task UpdateRoleAsync(Role role);

    }
}
