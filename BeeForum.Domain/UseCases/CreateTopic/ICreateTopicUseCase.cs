using BeeForum.Domain.Models;

namespace BeeForum.Domain.UseCases.CreateTopic
{
    public interface ICreateTopicUseCase
    {
        Task<DomainTopic> Execute(Guid forumId, string title, Guid authorId, CancellationToken cancellationToken);
    }
}
