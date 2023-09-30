using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeForum.Domain
{
    public interface IMomenProvider
    {
        DateTimeOffset Now { get; }
    }

    public class MomentProvider : IMomenProvider
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
    }
}
