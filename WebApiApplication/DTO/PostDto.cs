namespace WebApiApplication.DTO
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public string? BlogUrl { get; set; }

        public IEnumerable<string>? TagValues { get; set; }
    }
}
