using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CQRS.Inspector
{
    public class EventViewModel
    {
        public string Type { get; private set; }
        public int SequenceNumber { get; private set; }
        public DateTime CreatedTimeStamp { get; private set; }
        public string SerializedEvent { get; private set; }
        public ObservableCollection<EventPropertiesViewModel> Properties { get; private set; }
        public Guid Id { get; private set; }

        public EventViewModel(Guid id, string type, int sequenceNumber, DateTime createdTimeStamp, IEnumerable<EventPropertiesViewModel> properties)
        {
            Id = id;
            Type = type;
            SequenceNumber = sequenceNumber;
            CreatedTimeStamp = createdTimeStamp;
            Properties = new ObservableCollection<EventPropertiesViewModel>(properties);
                             
        }
    }
}