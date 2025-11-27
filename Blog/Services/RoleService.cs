using Blog.API.Models;
using Blog.API.Models.DTOs.Category;
using Blog.API.Models.DTOs.Role;
using Blog.API.Repositories;
using Blog.API.Repositories.Interfaces;
using Blog.API.Services.Interfaces;

namespace Blog.API.Services
{
    public class RoleService : IRoleService
    {
        private RoleRepository _roleRepository;

        public RoleService(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<List<RoleResponseDTO>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllRolesAsync();
        }
        public async Task<RoleResponseDTO> GetRoleByIdAsync(int id)
        {
            return await _roleRepository.GetRoleByIdAsync(id);
        }
        public async Task CreateRoleAsync(RoleRequestDTO role)
        {
            var newRole = new Role(role.Name,
                                   role.Name.ToLower().Replace(" ", "-"));

            await _roleRepository.CreateRoleAsync(newRole);
        }

        public async Task DeleteRoleAsync(int id)
        {
            await _roleRepository.DeleteRoleAsync(id);
        }

        public async Task UpdateRoleAsync(RoleRequestDTO role, int id)
        {
            var newRole = new Role(role.Name,
                                   role.Name.ToLower().Replace(" ", "-"));

            newRole.SetId(id);
            await _roleRepository.UpdateRoleAsync(newRole);
        }

    }
}
