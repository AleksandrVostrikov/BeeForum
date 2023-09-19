using System.ComponentModel.DataAnnotations;

namespace BeeForum.Storage.Models
{
    public class Forum
    {
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; } = null!;
        public ICollection<Topic>? Topics { get; set; }
    }
}
