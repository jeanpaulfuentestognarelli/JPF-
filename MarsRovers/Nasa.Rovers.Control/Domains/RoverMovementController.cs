using Kernel;
using Nasa.Rovers.Control.DataObjects;
using System.Text.RegularExpressions;
using System.Globalization;
using Nasa.Rovers.Control.DomainEvents;
using Nasa.Rovers.Control.Enums;

namespace Nasa.Rovers.Control.Domains
{
    internal class RoverMovementController : Domain
    {
        public RoverMovementController(Dispatcher dispatcher) : base(dispatcher) { }        

        internal void MoveRover(Rover rover, string path) 
        {
            foreach (char instruction in path)
                ProcessInstruction(rover, instruction.ToString());                            
        }

        private void ProcessInstruction(Rover rover, string instruction)
        {
            instruction = instruction.ToUpper(CultureInfo.InvariantCulture);
            if (instruction == "M")
                SetMovement(rover);
            if (instruction == "L" || instruction == "R")
                SetOrientation(rover, instruction);
        }

        private void SetOrientation(Rover rover, string instruction)
        {
            int orientation = (int)rover.Orientation;
            int newOrientation = instruction == "L" ? orientation + 3 : orientation + 1;
            orientation = newOrientation % 4;



            AddEvent(new RoverInstructionReceived(new Rover(rover.X, rover.Y, (Orientation)orientation)));
        }

        private void SetMovement(Rover rover)
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
