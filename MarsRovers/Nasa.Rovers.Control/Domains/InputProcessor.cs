using Kernel;
using System.Text.RegularExpressions;
using Nasa.Rovers.Control.DataObjects;
using Nasa.Rovers.Control.DomainEvents;
using Nasa.Rovers.Control.Enums;

namespace Nasa.Rovers.Control.Domains
{
    internal class InputProcessor : Domain
    {
        private Queue<string> _inputQueue;        
        internal InputProcessor(Dispatcher dispatcher, string inputData) : base(dispatcher)
        {
            inputData = inputData.Trim();
            _inputQueue = new Queue<string>();

            string? line;
            using var sr = new StringReader(inputData);
            while ((line = sr.ReadLine()) != null) 
                _inputQueue.Enqueue(line);
        }

        internal void Process() 
        {         
            string? line;
            if (_inputQueue.TryDequeue(out line) == false)
                return;

            line = line.Trim();
            if (Regex.IsMatch(line, @"^\d+\s\d+$"))
                NewMapFromString(line);
            else if (Regex.IsMatch(line, @"^\d+\s\d+\s\w"))
                AddEvent(new RoverReceived(NewRover(line)));
            else if (Regex.IsMatch(line, @"(?i)^[A-Z]+"))
                AddEvent(new RoverPathReceived(line));
        }        
        private void NewMapFromString(string mapBase)
        {
            int width, height;
            int.TryParse(Regex.Match(mapBase, @"^\d+").Value, out width);
            int.TryParse(Regex.Match(mapBase, @"(?<=^\d+\D+)\d+").Value, out height);
            AddEvent(new MapReceived(new Map(width, height)));
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
