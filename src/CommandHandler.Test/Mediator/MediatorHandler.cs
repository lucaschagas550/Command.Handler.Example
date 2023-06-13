using MediatR;

namespace CommandHandler.Test.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator) =>
            _mediator = mediator;

        public async Task SendCommandAsync<T>(T comando) where T : class
        {
            await _mediator.Send(comando);
        }

        //Test
        public void SendCommand<T>(T comando) where T : class
        {
             _mediator.Send(comando);
        }
    }
}
