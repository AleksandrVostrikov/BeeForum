using BeeForum.Domain.Models;
using BeeForum.Domain.UseCases.GetForum;
using BeeForum.Storage.Data;
using Microsoft.EntityFrameworkCore;

namespace BeeForum.Domain.UseCases.GetForums
{
    public class GetForumsUseCase : IGetForumsUseCase
    {
        private readonly BeeForumDbContext _beeForumDbContext;

        public GetForumsUseCase(BeeForumDbContext beeForumDbContext)
        {
            _beeForumDbContext = beeForumDbContext;
        }
        public async Task<IEnumerable<Forum>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return await _beeForumDbContext.Forums
                .Select(f => new Forum
                {
                    Id = f.Id,
                    Title = f.Title
                })
                .ToArrayAsync(cancellationToken);
        }
    }
}
