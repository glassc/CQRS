using System;
using CQRS.Domain;
using UnitTests.Eventing;

namespace UnitTests.Domain
{
    public class TestAggregateRoot : AggregateRoot
    {
        public bool OnTestHasBeenCalled { get; private set; }

      

        public TestAggregateRoot(Guid id) : base(id)
        {
            Register<TestEvent>(OnTest);
        }

        public void Test(TestEvent @event)
        {
            Apply(@event);
        }

        public void TestWithNoHandler(TestEventWithNoHandler @event)
        {
            Apply(@event);
        }

        private void OnTest(TestEvent @event)
        {
            OnTestHasBeenCalled = true;
        }

        
    }
}