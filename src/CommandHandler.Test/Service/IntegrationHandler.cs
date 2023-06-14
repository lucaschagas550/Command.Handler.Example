using CommandHandler.Test.Model;

namespace CommandHandler.Test.Service
{
    public class IntegrationHandler : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            MeuEvento.Send += MeuEventHandler;

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            MeuEvento.Send -= MeuEventHandler;

            return Task.CompletedTask;
        }

        private void MeuEventHandler(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                // Lógica a ser executada quando o evento ocorrer
                var count = 0;
                Console.WriteLine($"Event Start: {DateTime.Now.ToString("HH:mm:ss.fff")}");

                while (count < 10000)
                {
                    count++;
                }
                Console.WriteLine($"Event End: {DateTime.Now.ToString("HH:mm:ss.fff")}");
            });

        }
    }
}
