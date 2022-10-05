using Kernel;
using Nasa.Rovers.Control.DataObjects;
using System.Text;

namespace Nasa.Rovers.Control.Domains
{
    internal class RoverWatcher : Domain
    {
        public List<Rover> Rovers { get; private set; }
        internal Map Map { get; private set; }
        public RoverWatcher(Dispatcher dispatcher) : base(dispatcher)
        {
            Map = new Map(0, 0);
            Rovers = new List<Rover>();
        }
        internal void SetMap(Map map) => Map = map;                
        internal void AddRover(Rover rover) => Rovers.Add(rover);
        internal string GetRoversStatus()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Rover rover in Rovers)
                sb.AppendLine(rover.ToString());
            return sb.ToString().Trim();
        }
        internal Rover GetCurrentRover() => Rovers.Last();

        internal void UpdateCurrentRover(Rover rover) 
        {
            if (Rovers == null || Rovers.Count == 0) 
                return;
            if (rover.X > Map.Width || rover.Y > Map.Height || rover.X < 0 || rover.Y < 0)
                rover = new Rover(-1, -1, rover.Orientation);

            Rovers.RemoveAt(Rovers.Count - 1);
            AddRover(rover);
        }
    }
}
