using Kernel;
using Nasa.Rovers.Control.DataObjects;

namespace Nasa.Rovers.Control.DomainEvents
{
    internal class RoverReceived : IDomainEvent
    {
        public Rover Rover { get; private set; }
        public RoverReceived(Rover rover)
        {
            Rover = rover;
        }
    }
}
