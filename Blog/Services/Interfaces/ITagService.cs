using Blog.API.Models;
using Blog.API.Models.DTOs.Tag;

namespace Blog.API.Services.Interfaces
{
    public interface ITagService
    {
        Task<List<TagResponseDTO>> GetAllTagsAsync();
        Task<TagResponseDTO> GetTagByIdAsync(int id);
        Task CreateTagAsync(TagRequestDTO tag);
        Task DeleteTagAsync(int id);
        Task UpdateTagAsync(TagRequestDTO tag, int id);
       
    }
}
