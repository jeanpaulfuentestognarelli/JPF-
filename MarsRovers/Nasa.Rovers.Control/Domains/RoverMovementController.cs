using Kernel;
using Nasa.Rovers.Control.DataObjects;
using System.Globalization;
using Nasa.Rovers.Control.DomainEvents;
using Nasa.Rovers.Control.Enums;

namespace Nasa.Rovers.Control.Domains
{
    internal class RoverMovementController : Domain
    {
        private readonly Queue<string> _instructions;
        public RoverMovementController(Dispatcher dispatcher) : base(dispatcher) 
        {
            _instructions = new Queue<string>();
        }        

        internal void MoveRover(string path) 
        {
            foreach (char instruction in path)
                _instructions.Enqueue(instruction.ToString());
            ProcessInstruction();
        }
        internal void ProcessInstruction()
        {
            string? instruction;
            if (_instructions.TryDequeue(out instruction) == false)
            {
                AddEvent(new MovementFinished());
                return;
            }

            instruction = instruction.ToUpper(CultureInfo.InvariantCulture);
            if (instruction == "M")
                AddEvent(new MoveInstructionSent());
            if (instruction == "L" || instruction == "R")
                AddEvent(new OrientationInstructionSent(instruction));
        }

        internal void SetOrientation(Rover rover, string instruction)
        {
            int orientation = (int)rover.Orientation;
            int newOrientation = instruction == "L" ? orientation + 3 : orientation + 1;
            orientation = newOrientation % 4;

            AddEvent(new RoverInstructionReceived(new Rover(rover.X, rover.Y, (Orientation)orientation)));
        }

        internal void SetMovement(Rover rover)
        {
            int newX = rover.X, newY = rover.Y;
            switch (rover.Orientation) 
            {
                case Orientation.N:
                    newY++;
                    break;
                case Orientation.E:
                    newX++;
                    break;
                case Orientation.S:
                    newY--;
                    break;
                case Orientation.W:
                    newX--;
                    break;
            }
            AddEvent(new RoverInstructionReceived(new Rover(newX, newY, rover.Orientation)));
        }
    }
}
