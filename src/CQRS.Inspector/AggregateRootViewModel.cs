using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CQRS.Inspector
{
    public class AggregateRootViewModel
    {
        public string Type { get; private set; }
        public Guid Id { get; private set; }
        public ObservableCollection<EventViewModel> Events {get; private set;}


        public AggregateRootViewModel(Guid id, string type, IEnumerable<EventViewModel> events)
        {
            Id = id;
            Type = type;
            Events = new ObservableCollection<EventViewModel>(events);
        }

        public override string ToString()
        {
            return Type;
        }
    }
}