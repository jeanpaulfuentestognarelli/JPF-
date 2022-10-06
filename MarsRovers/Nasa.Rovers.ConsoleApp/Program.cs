using Nasa.Rovers.Control;

try
{
    using (var sr = new StreamReader("Rovers.txt"))
    {
        string input = sr.ReadToEnd();
        RoverControl roverControl = new(input);

        roverControl.Start();
        string result = roverControl.CurrentPositions;
        Console.WriteLine(result);
        Console.ReadKey();
    }
}
catch (IOException e)
{
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
    Console.ReadKey();
}
