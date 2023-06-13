using CommandHandler.Test.Application.Commands;
using MediatR;

namespace CommandHandler.Test.Application.Handlers
{
    public class PersonCommandHandler : IRequestHandler<CreatePersonCommand, Unit> // CommandHandler pode ter acesso ao repositorio por exemplo
    {
        public async Task<Unit> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("handler is here.");
            Console.WriteLine(Unit.Value);
            Console.WriteLine($"Final Mediator: {DateTime.Now.ToString("HH:mm:ss.fff")}");
            return Unit.Value;
        }
    }
}
