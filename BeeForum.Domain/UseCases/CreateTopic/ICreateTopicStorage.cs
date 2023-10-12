using BeeForum.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeForum.Domain.UseCases.CreateTopic
{
    public interface ICreateTopicStorage
    {
        Task<bool> ForumExist(Guid id, CancellationToken cancellationToken);
        Task<Topic> CreateTopic(Guid forumId, Guid userId, string title, CancellationToken cancellationToken);
    }
}
