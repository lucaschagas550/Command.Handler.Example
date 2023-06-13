using MediatR;

namespace CommandHandler.Test.Application.Commands
{
    public class CreatePersonCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public CreatePersonCommand() { }

        public CreatePersonCommand(string name, int age)
        {
            Name=name;
            Age=age;
        }
    }
}
