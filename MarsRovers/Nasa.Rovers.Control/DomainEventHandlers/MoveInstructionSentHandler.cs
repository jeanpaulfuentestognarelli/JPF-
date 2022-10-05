using Kernel;
using Nasa.Rovers.Control.DomainEvents;
using Nasa.Rovers.Control.Domains;

namespace Nasa.Rovers.Control.DomainEventHandlers
{
    internal class MoveInstructionSentHandler : DomainEventHandler
    {
        public RoverWatcher RoverWatcher { get; private set; }
        public RoverMovementController RoverMovementController { get; set; }
        public MoveInstructionSentHandler(Dispatcher dispatcher, RoverWatcher roverWatcher, RoverMovementController roverMovementController) : base(dispatcher)
        {
            RoverWatcher = roverWatcher;
            RoverMovementController = roverMovementController;
        }

        public override void Handle(IDomainEvent domainEvent)
        {
            RoverMovementController.SetMovement(RoverWatcher.GetCurrentRover());
        }
    }
}
