using Kernel;
using Nasa.Rovers.Control.DataObjects;
using Nasa.Rovers.Control.DomainEvents;
using Nasa.Rovers.Control.Domains;

namespace Nasa.Rovers.Control.DomainEventHandlers
{
    internal class RoverPathReceivedHandler : DomainEventHandler
    {
        public RoverWatcher RoverWatcher { get; private set; }
        public RoverMovementController RoverMovementController { get; private set; }

        public RoverPathReceivedHandler(Dispatcher dispatcher, RoverWatcher roverWatcher, RoverMovementController roverMovementController) : base(dispatcher)
        {
            RoverMovementController = roverMovementController;
            RoverWatcher = roverWatcher;
        }

        public override void Handle(IDomainEvent domainEvent)
        {
            string path = ((RoverPathReceived)domainEvent).Path;           
            RoverMovementController.MoveRover(path);
        }
    }
}
