using BeeForum.Domain.Models;

namespace BeeForum.Domain.UseCases.GetForum
{
    public interface IGetForumsUseCase
    {
        Task<IEnumerable<DomainForum>> ExecuteAsync(CancellationToken cancellationToken);
    }
}
