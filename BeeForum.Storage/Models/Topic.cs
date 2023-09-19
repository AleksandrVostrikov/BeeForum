using System.ComponentModel.DataAnnotations;

namespace BeeForum.Storage.Models
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
        public User Author { get; set; } = null!;
        public Forum Forum { get; set; } = null!;
        public ICollection<Comment>? Comments { get; set; }
    }
}
