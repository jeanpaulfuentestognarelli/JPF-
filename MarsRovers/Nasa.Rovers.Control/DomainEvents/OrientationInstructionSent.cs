using Kernel;
using Nasa.Rovers.Control.DataObjects;

namespace Nasa.Rovers.Control.DomainEvents
{
    internal class OrientationInstructionSent : IDomainEvent
    {
        public string Instruction { get; private set; }

        public OrientationInstructionSent(string instruction)
        {
            Instruction = instruction;
        }
    }
}
