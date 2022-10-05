using Kernel;
using System.Text.RegularExpressions;
using Nasa.Rovers.Control.DataObjects;
using Nasa.Rovers.Control.DomainEvents;
using Nasa.Rovers.Control.Enums;

namespace Nasa.Rovers.Control.Domains
{
    internal class InputProcessor : Domain
    {
        internal string InputData { get; private set; }
        internal InputProcessor(Dispatcher dispatcher, string inputData) : base(dispatcher) => InputData = inputData;

        internal void Process() 
        {
            if (InputData == null) return;

            StringReader reader = new StringReader(InputData);
            string? mapLine = reader.ReadLine();            
            if (mapLine == null) return;

            NewMapFromString(mapLine);
            ReceiveRovers(InputData); 

        }        

        private void  NewMapFromString(string mapBase)
        {
            int width, height;
            int.TryParse(Regex.Match(mapBase, @"^\d+").Value, out width);
            int.TryParse(Regex.Match(mapBase, @"(?<=^\d+\D+)\d+").Value, out height);
            AddEvent(new MapReceived(new Map(width, height)));
        }

        private void ReceiveRovers(string inputData)
        {
            int count = 0;
            string? line;
            using var sr = new StringReader(inputData);

            while ((line = sr.ReadLine()) != null)            
                SendRover(line, count++);                            
        }

        private void SendRover(string line, int index)
        {            
            if(index == 0) return;
            line = line.Trim();
            if (Regex.IsMatch(line, @"^\d+\s\d+\s\w"))
                AddEvent(new RoverReceived(NewRover(line)));
            else if (Regex.IsMatch(line, @"(?i)^[A-Z]+"))
                AddEvent(new RoverPathReceived(line));
        }

        private Rover NewRover(string line)
        {
            int x, y;
            int.TryParse(Regex.Match(line, @"^\d+").Value, out x);
            int.TryParse(Regex.Match(line, @"(?<=^\d+\s)\d+").Value, out y);
            Orientation orientation;
            Enum.TryParse(Regex.Match(line, @"(?<=^\d+\s\d+\s).*").Value, out orientation);

            return new Rover
                (
                    X: x,
                    Y: y,
                    Orientation: orientation
                );
        }
    }
}
