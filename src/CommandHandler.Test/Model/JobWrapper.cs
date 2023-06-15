namespace CommandHandler.Test.Model
{
    public class JobWrapper
    {
        private bool _isRunning;

        public event Action<string> JobCompleted;

        public JobWrapper()
        {
            JobCompleted += OnJobCompleted;

        }

        public void StartJob()
        {
            if (_isRunning)
            {
                Console.WriteLine("Job is already running.");
                return;
            }

            _isRunning = true;
            
            Task.Run( () =>
                {
                    ExecuteJob();
                });
        }

        public void StopJob()
        {
            if (!_isRunning)
            {
                Console.WriteLine("Job is not running.");
                return;
            }

            _isRunning = false;
        }

        private void ExecuteJob()
        {
            Console.WriteLine("Job started.");

            // Simulate some work
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Working... {i}");
                Thread.Sleep(1000); // Wait for 1 second
            }

            Console.WriteLine("Job completed.");

            // Trigger the JobCompleted event
            JobCompleted?.Invoke("Job completed successfully.");
        }

        private void OnJobCompleted(string message)
        {
            Console.WriteLine("JobWrapper: " + message);
        }
    }
}
