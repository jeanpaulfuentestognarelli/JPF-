
using Kernel;
using Nasa.Rovers.Control.DomainEventHandlers;
using Nasa.Rovers.Control.Domains;

namespace Nasa.Rovers.Control
{
    public class RoverControl
    {
        public string CurrentPositions { get; private set; }
        public string Actions { get; private set; }

        public RoverControl(string actions)
        {
            Actions = actions;
            CurrentPositions = string.Empty;
           
        }

        public void Start() 
        {
            Dispatcher dispatcher = new Dispatcher();
            InputProcessor inputProcessor = new InputProcessor(dispatcher, Actions);
            RoverWatcher roverWatcher = new RoverWatcher(dispatcher);
            RoverMovementController roverMovementController = new RoverMovementController(dispatcher);

            MapReceivedHandler mapReceivedHandler = new MapReceivedHandler(dispatcher, roverWatcher);
            RoverReceivedHandler roverReceivedHandler = new RoverReceivedHandler(dispatcher, roverWatcher);
            RoverPathReceivedHandler roverPathReceivedHandler = new RoverPathReceivedHandler(dispatcher, roverWatcher, roverMovementController);
            RoverInstructionReceivedHandler roverInstructionReceivedHandler = new RoverInstructionReceivedHandler(dispatcher, roverWatcher, roverMovementController);
            OrientationInstructionSentHandler orientationInstructionSentHandler = new OrientationInstructionSentHandler(dispatcher, roverWatcher, roverMovementController);
            MoveInstructionSentHandler moveInstructionSentHandler = new MoveInstructionSentHandler(dispatcher, roverWatcher, roverMovementController);

            inputProcessor.Process();
            dispatcher.DispatchEvents();
            CurrentPositions = roverWatcher.GetRoversStatus();
        }
                
    }
}
