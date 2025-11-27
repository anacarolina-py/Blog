namespace Blog.API.Models
{
    public class PostTag
    {
        public int PostId { get; private set; }
        public Post Post { get; private set; }
        public int TagId { get; private set; }
        public Tag Tag { get; private set; }
    }
}
