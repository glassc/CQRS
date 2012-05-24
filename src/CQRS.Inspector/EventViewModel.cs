using System;
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

        public EventViewModel(string type, int sequenceNumber, DateTime createdTimeStamp, string serializedEvent)
        {
            Type = type;
            SequenceNumber = sequenceNumber;
            CreatedTimeStamp = createdTimeStamp;
            SerializedEvent = serializedEvent;

            Properties = new ObservableCollection<EventPropertiesViewModel>
                             {
                                 new EventPropertiesViewModel("Name", "Chris", "String"),
                                 new EventPropertiesViewModel("Age", "29", "Int32")
                             };
        }
    }
}