namespace Blog.API.Models
{
    public class PostTag
    {
        public int Id { get; private set; }
        public int PostId { get; private set; }
        public int TagId { get; private set; }

    }
}
