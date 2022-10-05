using Nasa.Rovers.Control.Enums;

namespace Nasa.Rovers.Control.DataObjects
{
    internal readonly record struct Rover(int X, int Y, Orientation Orientation) 
    {
        public override string ToString()
        {
            return $"{X} {Y} {Orientation}";
        }
    }
}
