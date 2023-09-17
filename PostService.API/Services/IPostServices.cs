using PostService.API.Models;

namespace PostService.API.Services
{
    public interface IPostServices
    {
        Task<Post> AddAsync(Post post);
        Task<Post> EditAsync(Post post);
        Task<bool> DeleteAsync(string id);
        Task<Post> GetByIdAsync(string id);
        Task<IEnumerable<Post>> GetAllAsync();
    }
}
