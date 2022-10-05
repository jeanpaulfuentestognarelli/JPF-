namespace Kernel
{
    public abstract class DomainEventHandler
    {
        public DomainEventHandler(Dispatcher dispatcher)
        {
            dispatcher.AddHandler(this);
        }
        public abstract void Handle(IDomainEvent domainEvent);
    }
}
