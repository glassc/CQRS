using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CQRS.Inspector
{
    public class EventListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<EventViewModel> events;
 
        public ObservableCollection<EventViewModel> Events
        {
            get { return events; }
            set
            {
                events = value;
                RaisePropertyChanged("Events");
            }
        }

        public EventListViewModel() : this(new FakeEventsProvider())
        {
        }

        public EventListViewModel(IEventsProvider eventsProvider)
        {
            Events = new ObservableCollection<EventViewModel>(eventsProvider.Get());
                     
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
