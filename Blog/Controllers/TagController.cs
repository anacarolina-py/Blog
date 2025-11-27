using Blog.API.Models.DTOs.Role;
using Blog.API.Models.DTOs.Tag;
using Blog.API.Services;
using Blog.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private TagService _tagService;
        public TagController(TagService service)
        {
            _tagService = service;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("API is running.");

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<TagResponseDTO>>> GetAllTags()
        {
            try
            {
                var tags = await _tagService.GetAllTagsAsync();
                return Ok(tags);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<TagResponseDTO>> GetTagById(int id)
        {
            try
            {
                var tag = await _tagService.GetTagByIdAsync(id);
                return Ok(tag);
            }
            catch (Exception ex)
            {
                return BadRequest($"Tag {id} was not found");
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateTag(TagRequestDTO tag)
        {
            try
            {
                await _tagService.CreateTagAsync(tag);

                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteTag(int id)
        {
            try
            {
                await _tagService.DeleteTagAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> UpdateTag(int id, [FromBody] TagRequestDTO tag)
        {
            try
            {
                await _tagService.UpdateTagAsync(tag, id);
                return Ok($"Update tag with id: {id}");
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
