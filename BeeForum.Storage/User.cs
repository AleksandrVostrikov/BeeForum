using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeForum.Storage
{
    public class User
    {
        public Guid Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; } = null!;

        [InverseProperty(nameof(Comment.Author))]
        public ICollection<Comment>? Comments { get; set; }
        [InverseProperty(nameof(Topic.Author))]
        public ICollection<Topic>? Topics { get; set; }
    }
}
