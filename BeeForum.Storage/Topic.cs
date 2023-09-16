using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeForum.Storage
{
    public class Topic
    {
        public Guid Id { get; set; }
        public Guid ForumId { get; set; }
        public Guid UserId { get; set; }
        [MaxLength(100)]
        public string Title { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public User Author { get; set; } = null!;
        [ForeignKey(nameof(ForumId))]
        public Forum Forum { get; set; } = null!;

        [InverseProperty(nameof(Comment.Topic))]
        public ICollection<Comment>? Comments { get; set; }
    }
}
