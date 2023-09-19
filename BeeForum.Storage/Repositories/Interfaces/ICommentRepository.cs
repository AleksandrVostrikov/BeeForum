using BeeForum.Storage.Models;

namespace BeeForum.Storage.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<Forum> GetForumAsync(Comment c);
        Task<Topic> GetTopicAsync(Comment c);
        Task<User> GetUserAsync(Comment c);
        Task<Comment> GetCommentByIdAsync(Guid id);
        Task CreateCommentAsync(Comment c);
        Task UpdateCommentAsync(Comment c);
        Task DeleteCommentAsync(Comment c);
    }
}
