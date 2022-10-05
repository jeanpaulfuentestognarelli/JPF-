using Kernel;
using Nasa.Rovers.Control.DataObjects;

namespace Nasa.Rovers.Control.DomainEvents
{
    internal class RoverInstructionReceived : IDomainEvent
    {
        public Rover Rover { get; private set; }
        public RoverInstructionReceived(Rover rover)
        {
            Rover = rover;
        }
    }
}
