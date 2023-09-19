namespace BeeForum.Storage.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid ForumId { get; set; }
        public Guid UserId { get; set; }
        public Guid TopicId { get; set; }
        public string Text { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public User Author { get; set; } = null!;
        public Topic Topic { get; set; } = null!;
        public Forum Forum { get; set; } = null!;



    }
}
