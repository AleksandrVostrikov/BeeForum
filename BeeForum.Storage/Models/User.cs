using System.ComponentModel.DataAnnotations;

namespace BeeForum.Storage.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; } = null!;
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Topic>? Topics { get; set; }
    }
}
