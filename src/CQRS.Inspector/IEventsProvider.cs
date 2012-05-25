using System.Collections.Generic;

namespace CQRS.Inspector
{
    public interface IEventsProvider
    {
        IEnumerable<EventViewModel> Get();
    }
}