using BeeForum.Domain.Exceptions;
using BeeForum.Domain.Models;
using BeeForum.Storage.Data;
using Microsoft.EntityFrameworkCore;

namespace BeeForum.Domain.UseCases.CreateTopic
{
    public class CreateTopicUseCase : ICreateTopicUseCase
    {
        private readonly BeeForumDbContext _beeForumDbContext;
        private readonly IGuidFactory _guidFactory;
        private readonly IMomenProvider _momenProvider;

        public CreateTopicUseCase(BeeForumDbContext beeForumDbContext, IGuidFactory guidFactory, IMomenProvider momenProvider)
        {
            _beeForumDbContext = beeForumDbContext;
            _guidFactory = guidFactory;
            _momenProvider = momenProvider;
        }

        public async Task<Topic> Execute(Guid forumId, string title, Guid authorId, CancellationToken cancellationToken)
        {
            var forumExists = await _beeForumDbContext.Forums.AnyAsync(f => f.Id == forumId, cancellationToken);
            if (!forumExists)
            {
                throw new ForumNotfoundException(forumId);
            }
            var topicId = _guidFactory.Create();
            await _beeForumDbContext.Topics.AddAsync(new Storage.Models.Topic
            {
                Id = topicId,
                ForumId = forumId,
                UserId = authorId,
                Title = title,
                CreatedAt = _momenProvider.Now
            }, cancellationToken) ;
            await _beeForumDbContext.SaveChangesAsync(cancellationToken);

           return  await _beeForumDbContext.Topics
                .Where(t => t.Id == topicId)
                .Select(t => new Topic
                {
                    Id = t.Id,
                    Title = t.Title,
                    CreatedAt = t.CreatedAt,
                    Author = t.Author.Name
                }).FirstAsync(cancellationToken);
        }
    }
}
