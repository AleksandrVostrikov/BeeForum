using BeeForum.Storage.Models;

namespace BeeForum.Storage.Repositories.Interfaces
{
    public interface IForumRepository
    {
        Task<IQueryable<Forum>> GetAllForumsAsync();
        Task<IQueryable<Topic>> GetAllForumTopicsAsync(Guid id);
        Task<Forum> GetForumAsync(Guid id);
        Task CreateForumAsync(Forum f);
        Task UpdateForumAsync(Forum f);
        Task DeleteForumAsync(Forum f);
    }
}
