using Blog.API.Models.DTOs.Role;
using Blog.API.Models.DTOs.Tag;
using Blog.API.Models.DTOs.User;
using Blog.API.Services;
using Blog.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        public UserController(UserService service)
        {
            _userService = service;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("API is running.");

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<UserResponseDTO>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<UserResponseDTO>> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateUser(UserRequestDTO user)
        {
            try
            {
                await _userService.CreateUserAsync(user);

                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdatePassword/{id}")]
        public async Task<ActionResult> UpdateUserPassword(int id, [FromBody] UpdatePasswordDTO senha)
        {
            try
            {
                await _userService.UpdatePasswordUserAsync(senha.PasswordHash, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateBio/{id}")]
        public async Task<ActionResult> UpdateUserBio(int id, [FromBody] UpdateBioDTO bio)
        {
            try
            {
                await _userService.UpdateBioUserAsync(bio.Bio, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("UpdateImage/{id}")]
        public async Task<ActionResult> UpdateUserImage(int id, [FromBody] UpdateImageDTO image)
        {
            try
            {
                await _userService.UpdateImageUserAsync(image.Image, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
