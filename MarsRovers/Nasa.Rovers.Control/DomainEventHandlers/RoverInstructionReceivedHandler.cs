using Kernel;
using Nasa.Rovers.Control.DomainEvents;
using Nasa.Rovers.Control.Domains;

namespace Nasa.Rovers.Control.DomainEventHandlers
{
    internal class RoverInstructionReceivedHandler : DomainEventHandler
    {
        public RoverWatcher RoverWatcher { get; private set; }
        public RoverInstructionReceivedHandler(Dispatcher dispatcher, RoverWatcher roverWatcher) : base(dispatcher)
        {
            RoverWatcher = roverWatcher;
        }

        public override void Handle(IDomainEvent domainEvent)
        {
            RoverWatcher.UpdateCurrentRover(((RoverInstructionReceived)domainEvent).Rover);
        }
    }
}
