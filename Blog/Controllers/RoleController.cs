using Blog.API.Models.DTOs.Category;
using Blog.API.Models.DTOs.Role;
using Blog.API.Services;
using Blog.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private RoleService _roleService;
        public RoleController(RoleService service)
        {
            _roleService = service;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("API is running.");

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<RoleResponseDTO>>> GetAllRoles()
        {
            try
            {
                var roles = await _roleService.GetAllRolesAsync();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<RoleResponseDTO>> GetRoleById(int id)
        {
            try
            {
                var role = await _roleService.GetRoleByIdAsync(id);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateRole(RoleRequestDTO role)
        {
            try
            {
                await _roleService.CreateRoleAsync(role);

                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteRole(int id)
        {
            try
            {
                await _roleService.DeleteRoleAsync(id);
                return NoContent();
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> UpdateRole(int id, [FromBody] RoleRequestDTO role)
        {
            try
            {
                await _roleService.UpdateRoleAsync(role, id);
                return Ok($"Update role with id: {id}");
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }
    }
}
