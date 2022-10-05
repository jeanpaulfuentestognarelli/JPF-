using Kernel;
using Nasa.Rovers.Control.DataObjects;
using System.Text;

namespace Nasa.Rovers.Control.Domains
{
    internal class RoverWatcher : Domain
    {
        private readonly List<Rover> _rovers;
        internal Map Map { get; private set; }
        public RoverWatcher(Dispatcher dispatcher) : base(dispatcher)
        {
            Map = new Map(0, 0);
            _rovers = new List<Rover>();
        }
        internal void SetMap(Map map) => Map = map;                
        internal void AddRover(Rover rover) => _rovers.Add(rover);
        internal string GetRoversStatus()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Rover rover in _rovers)
                sb.AppendLine(rover.ToString());
            return sb.ToString().Trim();
        }
        internal Rover GetCurrentRover() => _rovers.Last();

        internal void UpdateCurrentRover(Rover rover) 
        {
            if (_rovers == null || _rovers.Count == 0) 
                return;

            _rovers[_rovers.Count - 1] = rover;
        }
    }
}
