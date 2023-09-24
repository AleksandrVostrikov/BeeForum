using BeeForum.Domain.Models;

namespace BeeForum.Domain.UseCases.CreateTopic
{
    internal class CreateTopicUseCase : ICreateTopicUseCase
    {
        public Task<DomainTopic> Execute(Guid forumId, string title, Guid authorId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
