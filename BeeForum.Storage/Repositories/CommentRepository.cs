using BeeForum.Storage.Data;
using BeeForum.Storage.Models;
using BeeForum.Storage.Repositories.Interfaces;

namespace BeeForum.Storage.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BeeForumDbContext _beeForumDbContext;

        public CommentRepository(BeeForumDbContext beeForumDbContext)
        {
            _beeForumDbContext = beeForumDbContext;
        }
        public async Task CreateCommentAsync(Comment c)
        {
            await _beeForumDbContext.Comments.AddAsync(c);
        }

        public Task DeleteCommentAsync(Comment c)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetCommentByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Forum> GetForumAsync(Comment c)
        {
            throw new NotImplementedException();
        }

        public Task<Topic> GetTopicAsync(Comment c)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(Comment c)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCommentAsync(Comment c)
        {
            throw new NotImplementedException();
        }
    }
}
