using System;
using CQRS.Eventing;

namespace CQRS.Domain
{
    public class Do
    {
        public static readonly Action<Event> Nothing = (e) => { };
    }
}