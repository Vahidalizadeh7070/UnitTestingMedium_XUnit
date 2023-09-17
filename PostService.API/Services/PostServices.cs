using Microsoft.EntityFrameworkCore;
using PostService.API.Models;

namespace PostService.API.Services
{
    public class PostServices : IPostServices
    {
        private readonly AppDbContext _dbContext;

        public PostServices(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Post> AddAsync(Post post)
        {
            if(post is not null)
            {
                await _dbContext.Posts.AddAsync(post);
                await _dbContext.SaveChangesAsync();
            }
            return post;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var post = await GetPost(id);
            if(post is not null)
            {
                _dbContext.Posts.Remove(post);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Post> EditAsync(Post post)
        {
            var postObj = await GetPost(post.Id);
            if(postObj is not null)
            {
                postObj.Title = post.Title;
                postObj.UserName = post.UserName;
                await _dbContext.SaveChangesAsync();
            }
            return post;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _dbContext.Posts.ToListAsync();
        }

        public async Task<Post> GetByIdAsync(string id)
        {
            return await GetPost(id);
        }

        private async Task<Post> GetPost(string id)
        {
            return await _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
