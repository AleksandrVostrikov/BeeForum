using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeForum.Storage
{
    public class Forum
    {
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; } = null!;

        [InverseProperty(nameof(Topic.Forum))]
        public ICollection<Topic>? Topics { get; set; }
    }
}
