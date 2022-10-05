using Kernel;
using Nasa.Rovers.Control.DomainEvents;
using Nasa.Rovers.Control.Domains;

namespace Nasa.Rovers.Control.DomainEventHandlers
{
    internal class OrientationInstructionSentHandler : DomainEventHandler
    {
        public RoverWatcher RoverWatcher { get; private set; }
        public RoverMovementController RoverMovementController { get; private set; }
        public OrientationInstructionSentHandler(Dispatcher dispatcher, RoverWatcher roverWatcher, RoverMovementController roverMovementController) : base(dispatcher)
        {
            RoverWatcher = roverWatcher;
            RoverMovementController = roverMovementController;
        }

        public override void Handle(IDomainEvent domainEvent)
        {
            string instruction = ((OrientationInstructionSent)domainEvent).Instruction;
            RoverMovementController.SetOrientation(RoverWatcher.GetCurrentRover(), instruction);
        }
    }
}
