using Blog.API.Models;
using Blog.API.Models.DTOs.Role;
using Blog.API.Models.DTOs.Tag;
using Blog.API.Repositories;
using Blog.API.Repositories.Interfaces;
using Blog.API.Services.Interfaces;

namespace Blog.API.Services
{
    public class TagService : ITagService
    {
        private TagRepository _tagRepository;

        public TagService(TagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task<List<TagResponseDTO>> GetAllTagsAsync()
        {
            return await _tagRepository.GetAllTagsAsync();
        }
        public async Task<TagResponseDTO> GetTagByIdAsync(int id)
        {
            return await _tagRepository.GetTagByIdAsync(id);
        }
        public async Task CreateTagAsync(TagRequestDTO tag)
        {
            var newTag = new Tag(tag.Name,
                                   tag.Name.ToLower().Replace(" ", "-"));

            await _tagRepository.CreateTagAsync(newTag);
        }

        public async Task DeleteTagAsync(int id)
        {
            await _tagRepository.DeleteTagAsync(id);
        }

        public async Task UpdateTagAsync(TagRequestDTO tag, int id)
        {
            var newTag = new Tag(tag.Name,
                                  tag.Name.ToLower().Replace(" ", "-"));

            newTag.SetId(id);
            await _tagRepository.UpdateTagAsync(newTag);
        }
    }
}
