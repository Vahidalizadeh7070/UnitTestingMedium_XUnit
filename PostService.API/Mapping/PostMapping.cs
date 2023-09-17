using Mapster;
using PostService.API.DTO;
using PostService.API.Models;

namespace PostService.API.Mapping
{
    public class PostMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreatePostDTO, Post>()
                .Map(d => d.Id, src => src.Id)
                .Map(d => d.Title, src => src.Title)
                .Map(d => d.UserName, src => src.UserName)
                .Map(d => d.CreatedAt, src => src.CreatedAt);

            config.NewConfig<Post, ResponsePostDTO>()
                .Map(d => d.Id, src => src.Id)
                .Map(d => d.Title, src => src.Title)
                .Map(d => d.UserName, src => src.UserName)
                .Map(d => d.CreatedAt, src => src.CreatedAt);

            config.NewConfig<UpdatePostDTO, Post>()
                .Map(d => d.Id, src => src.Id)
                .Map(d => d.Title, src => src.Title)
                .Map(d => d.UserName, src => src.UserName)
                .Map(d => d.CreatedAt, src => src.CreatedAt);
        }
    }
}
