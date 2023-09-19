using BeeForum.Storage.Data;
using BeeForum.Storage.Models;
using BeeForum.Storage.Repositories.Interfaces;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;

namespace BeeForum.Storage.Repositories
{
    public class ForumRepository : IForumRepository
    {
        private readonly BeeForumDbContext _beeForumDbContext;

        public ForumRepository(BeeForumDbContext BeeForumDbContext)
        {
            _beeForumDbContext = BeeForumDbContext;
        }
        public async Task<IQueryable<Forum>> GetAllForumsAsync()
        {
            return await Task.FromResult(_beeForumDbContext.Forums);
        }
        public async Task<Forum> GetForumAsync(Guid id)
        {
            return await _beeForumDbContext.Forums
               .FirstOrDefaultAsync(f => f.Id == id);
               //?? new Forum() { Title = "Нет такого форума" };
        }
        public async Task CreateForumAsync(Forum f)
        {
            await _beeForumDbContext.Forums.AddAsync(f);
        }
        public async Task DeleteForumAsync(Forum f)
        {
            _beeForumDbContext.Forums.Remove(f);
            await _beeForumDbContext.SaveChangesAsync();
        }
        public async Task UpdateForumAsync(Forum f)
        {
            _beeForumDbContext.Forums.Update(f);
            await _beeForumDbContext.SaveChangesAsync();
        }
        public async Task<IQueryable<Topic>> GetAllForumTopicsAsync(Guid id)
        {
            return (IQueryable<Topic>)(await GetForumAsync(id)).Topics;
        }
    }
}
