namespace BeeForum.Domain.Models
{
    public class DomainTopic
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }
    }
}
