using System.ComponentModel.DataAnnotations;

namespace CommandHandler.Test.Mediator
{
    public interface IMediatorHandler
    {
        Task SendCommandAsync<T>(T command) where T : class;

        void SendCommand<T>(T comando) where T : class;
    }
}
