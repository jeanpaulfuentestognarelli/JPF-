using Kernel;
using Nasa.Rovers.Control.DataObjects;

namespace Nasa.Rovers.Control.DomainEvents
{
    internal class MapReceived : IDomainEvent
    {
        public Map Map { get; private set; }
        public MapReceived(Map map)
        {
            Map = map;
        }
    }
}
