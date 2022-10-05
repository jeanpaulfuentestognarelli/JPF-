namespace Kernel
{
    public class Domain
    {
        public Guid Id { get; private set; }
        private Dispatcher _dispatcher;
        public Domain(Dispatcher dispatcher)
        {
            Id = Guid.NewGuid();
            _dispatcher = dispatcher;
        }
        protected void AddEvent(IDomainEvent domainEvent)
        {
            _dispatcher.AddEvent(domainEvent);
        }
    }
}
