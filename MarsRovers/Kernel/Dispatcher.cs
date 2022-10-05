namespace Kernel
{
    public class Dispatcher
    {
        private Dictionary<string, List<DomainEventHandler>> _handlers;
        private Queue<IDomainEvent> _events;

        public Dispatcher()
        {
            _handlers = new Dictionary<string, List<DomainEventHandler>>();
            _events = new Queue<IDomainEvent>();
        }

        internal void AddHandler(DomainEventHandler handler)
        {
            string name = handler.GetType().Name.Replace("Handler", string.Empty);

            if (!_handlers.ContainsKey(name))
                _handlers[name] = new List<DomainEventHandler>();
            _handlers[name].Add(handler);
        }

        internal void AddEvent(IDomainEvent domainEvent)
        {
            _events.Enqueue(domainEvent);
        }

        public void DispatchEvents()
        {
            while (_events.Count > 0)
                MatchEvents();
        }

        private void MatchEvents()
        {
            IDomainEvent currentEvent = _events.Dequeue();
            string name = currentEvent.GetType().Name.Replace("Event", string.Empty);

            if (_handlers.ContainsKey(name))
                ActivateHandlers(name, currentEvent);
        }

        private void ActivateHandlers(string name, IDomainEvent currentEvent)
        {
            _handlers[name].ForEach(handler => handler.Handle(currentEvent));
        }
    }
}
