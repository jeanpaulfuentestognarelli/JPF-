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
        public void Rover1Movement1S()
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
        public void Rover1Movement1W()
        {
            string input = @"2 2
1 1 W
M";

            string expected = @"0 1 W";

            RoverControl roverControl = new(input);

            roverControl.Start();
            string result = roverControl.CurrentPositions;

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Rover1Movement1N()
        {
            string input = @"2 2
1 1 N
M";

            string expected = @"1 2 N";

            RoverControl roverControl = new(input);

            roverControl.Start();
            string result = roverControl.CurrentPositions;

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Rover1Movement1E()
        {
            string input = @"2 2
1 1 E
M";

            string expected = @"2 1 E";

            RoverControl roverControl = new(input);

            roverControl.Start();
            string result = roverControl.CurrentPositions;

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Rover1RotateRightAndMovement1S()
        {
            string input = @"2 2
1 1 S
RM";

            string expected = @"0 1 W";

            RoverControl roverControl = new(input);

            roverControl.Start();
            string result = roverControl.CurrentPositions;

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Rover1RotateRightAndMovement1W()
        {
            string input = @"2 2
1 1 W
RM";

            string expected = @"1 2 N";

            RoverControl roverControl = new(input);

            roverControl.Start();
            string result = roverControl.CurrentPositions;

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Rover1RotateRightAndMovement1N()
        {
            string input = @"2 2
1 1 N
RM";

            string expected = @"2 1 E";

            RoverControl roverControl = new(input);

            roverControl.Start();
            string result = roverControl.CurrentPositions;

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Rover1RotateRightAndMovement1E()
        {
            string input = @"2 2
1 1 E
RM";

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
        [Test]
        public void BaseTestOnlyFirst()
        {
            string input = @"5 5
1 2 N
LMLMLMLMM";
            string expected = @"1 3 N";
            RoverControl roverControl = new(input);

            roverControl.Start();
            string result = roverControl.CurrentPositions;

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void BaseTestOnlySecond()
        {
            string input = @"5 5
3 3 E
MMRMMRMRRM";
            string expected = @"5 1 E";
            RoverControl roverControl = new(input);

            roverControl.Start();
            string result = roverControl.CurrentPositions;

            Assert.AreEqual(expected, result);
        }
    }
}