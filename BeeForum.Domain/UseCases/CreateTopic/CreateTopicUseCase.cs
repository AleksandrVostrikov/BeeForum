using BeeForum.Domain.Exceptions;
using BeeForum.Domain.Models;
using BeeForum.Storage.Data;
using Microsoft.EntityFrameworkCore;

namespace BeeForum.Domain.UseCases.CreateTopic
{
    public class CreateTopicUseCase : ICreateTopicUseCase
    {
        private readonly ICreateTopicStorage _storage;

        public CreateTopicUseCase(ICreateTopicStorage createTopicStorage)
        {
            _storage = createTopicStorage;
        }

        public async Task<Topic> Execute(Guid forumId, string title, Guid authorId, CancellationToken cancellationToken)
        {
            var forumExists = await _storage.ForumExist(forumId, cancellationToken);
            if (!forumExists)
            {
                throw new ForumNotfoundException(forumId);
            }
            return await _storage.CreateTopic(forumId, authorId, title, cancellationToken);
        }
    }
}
