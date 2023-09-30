using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeForum.Domain.Exceptions
{
    public class ForumNotfoundException : Exception
    {
        public ForumNotfoundException(Guid forumId) : base($"Forum with {forumId} not found!")
        {
            
        }
    }
}
