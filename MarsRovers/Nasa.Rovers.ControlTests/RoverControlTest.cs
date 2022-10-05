using NUnit.Framework;
using Nasa.Rovers.Control;

namespace Nasa.Rovers.ControlTests
{
    public class RoverControlTest
    {     
        [Test]
        public void BaseTest()
        {
            string input = @"5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM";
            string expected = @"1 3 N
5 1 E";
            RoverControl roverControl = new(input);

            roverControl.Start();
            string result = roverControl.CurrentPositions;

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Rover1Movement1()
        {
            string input = @"2 2
1 1 S
M";

            string expected = @"1 0 S";

            RoverControl roverControl = new(input);

            roverControl.Start();
            string result = roverControl.CurrentPositions;

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Rover1Movement2()
        {
            string input = @"2 2
1 1 W
MLM";

            string expected = @"0 0 S";

            RoverControl roverControl = new(input);

            roverControl.Start();
            string result = roverControl.CurrentPositions;

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Rover1OutOfLine()
        {
            string input = @"2 2
1 1 W
MM";

            string expected = @"-1 -1 W";

            RoverControl roverControl = new(input);

            roverControl.Start();
            string result = roverControl.CurrentPositions;

            Assert.AreEqual(expected, result);
        }
    }
}