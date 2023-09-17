namespace PostService.API.DTO
{
    public class ResponsePostDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
}
