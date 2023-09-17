namespace PostService.API.Models
{
    public class Post
    {
        public string Id { get; set; }
        public string Title { get; set; }   
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
