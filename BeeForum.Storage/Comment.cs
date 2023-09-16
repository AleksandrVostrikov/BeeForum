using System.ComponentModel.DataAnnotations.Schema;

namespace BeeForum.Storage
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

        [ForeignKey(nameof(UserId))]
        public User Author { get; set; } = null!;
        [ForeignKey(nameof(TopicId))]
        public Topic Topic { get; set; } = null!;
    }
}
