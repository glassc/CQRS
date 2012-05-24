namespace CQRS.Inspector
{
    public class EventPropertiesViewModel
    {
        public string Name { get; private set; }
        public string Value { get; private set; }
        public string Type { get; private set; }

        public EventPropertiesViewModel(string name, string value, string type)
        {
            Name = name;
            Value = value;
            Type = type;
        }
    }
}