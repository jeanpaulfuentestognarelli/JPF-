using Kernel;
using Nasa.Rovers.Control.DomainEvents;
using Nasa.Rovers.Control.Domains;

namespace Nasa.Rovers.Control.DomainEventHandlers
{
    internal class RoverInstructionReceivedHandler : DomainEventHandler
    {
        public RoverMovementController RoverMovementController { get; private set; }
        public RoverWatcher RoverWatcher { get; private set; }
        public RoverInstructionReceivedHandler(Dispatcher dispatcher, RoverWatcher roverWatcher, RoverMovementController roverMovementController) : base(dispatcher)
        {
            RoverWatcher = roverWatcher;
            RoverMovementController = roverMovementController;
        }

        public override void Handle(IDomainEvent domainEvent)
        {
            RoverWatcher.UpdateCurrentRover(((RoverInstructionReceived)domainEvent).Rover);
            RoverMovementController.ProcessInstruction();
        }
    }
}
