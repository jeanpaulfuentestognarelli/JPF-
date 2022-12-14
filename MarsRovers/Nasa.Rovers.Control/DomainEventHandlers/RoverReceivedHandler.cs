using Kernel;
using Nasa.Rovers.Control.DomainEvents;
using Nasa.Rovers.Control.Domains;

namespace Nasa.Rovers.Control.DomainEventHandlers
{
    internal class RoverReceivedHandler : DomainEventHandler
    {
        public RoverWatcher RoverWatcher { get; private set; }
        public InputProcessor InputProcessor { get; private set; }
        public RoverReceivedHandler(Dispatcher dispatcher, RoverWatcher roverWatcher, InputProcessor inputProcessor) : base(dispatcher)
        {
            RoverWatcher = roverWatcher;
            InputProcessor = inputProcessor;
        }

        public override void Handle(IDomainEvent domainEvent)
        {
            RoverWatcher.AddRover(((RoverReceived)domainEvent).Rover);
            InputProcessor.Process();
        }
    }
}
