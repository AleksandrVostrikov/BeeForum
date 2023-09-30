using BeeForum.Domain.Models;

namespace BeeForum.Domain.UseCases.GetForum
{
    public interface IGetForumsUseCase
    {
        Task<IEnumerable<Forum>> ExecuteAsync(CancellationToken cancellationToken);
    }
}
