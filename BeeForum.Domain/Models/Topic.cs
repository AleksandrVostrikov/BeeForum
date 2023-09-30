namespace BeeForum.Domain.Models
{
    public class Topic
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }
    }
}
