using Kernel;

namespace Nasa.Rovers.Control.DomainEvents
{
    internal class RoverPathReceived : IDomainEvent
    {
        public string Path { get; private set; }
        public RoverPathReceived(string path)
        {
            Path = path;
        }
    }
}
