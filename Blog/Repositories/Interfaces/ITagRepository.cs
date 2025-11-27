using Blog.API.Models;
using Blog.API.Models.DTOs.Tag;
using System.Data.Common;

namespace Blog.API.Repositories.Interfaces
{
    public interface ITagRepository
    {
        Task<List<TagResponseDTO>> GetAllTagsAsync();
        Task<TagResponseDTO> GetTagByIdAsync(int id);
        Task CreateTagAsync(Tag tag);
        Task DeleteTagAsync(int id);
        Task UpdateTagAsync(Tag tag);
       
    }
}
