using NUnit.Framework;
using Nasa.Rovers.Control;

namespace Nasa.Rovers.ControlTests
{
    public class ProcessorTest
    {
        [Test]
        public void Rovers1InputTest()
        {
            string input = @"5 5
1 2 N";
            string expected = @"1 2 N";
            RoverControl roverControl = new(input);
            roverControl.Start();
            string result = roverControl.CurrentPositions;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Rovers2InputTest()
        {
            string input = @"5 5
1 2 N
3 3 E";
            string expected = @"1 2 N
3 3 E";
            RoverControl roverControl = new(input);
            roverControl.Start();
            string result = roverControl.CurrentPositions;

            Assert.AreEqual(expected, result);
        }
    }
}
