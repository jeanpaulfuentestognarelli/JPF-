using Kernel;
using Nasa.Rovers.Control.Domains;

namespace Nasa.Rovers.Control.DomainEventHandlers
{
    internal class MovementFinishedHandler : DomainEventHandler
    {
        public InputProcessor InputProcessor { get; private set; }
        public MovementFinishedHandler(Dispatcher dispatcher, InputProcessor inputProcessor) : base(dispatcher)
        {
            InputProcessor = inputProcessor;
        }

        public override void Handle(IDomainEvent domainEvent)
        {
            InputProcessor.Process();
        }
    }
}
