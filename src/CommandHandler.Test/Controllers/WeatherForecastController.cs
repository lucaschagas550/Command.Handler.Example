using CommandHandler.Test.Application.Commands;
using CommandHandler.Test.Mediator;
using CommandHandler.Test.Model;
using Microsoft.AspNetCore.Mvc;

namespace CommandHandler.Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediatorHandler _mediator;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediatorHandler mediator)
        {
            _logger = logger;
            _mediator=mediator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            //MediaTr
            //Console.WriteLine($"Start: {DateTime.Now.ToString("HH:mm:ss.fff")}");
            //Cria uma thread para executar separada do processo
            //Task.Run(() => _mediator.SendCommand(new CreatePersonCommand("lucas", 25)));

            //EventHandler com background service
            Console.WriteLine($"Start: {DateTime.Now.ToString("HH:mm:ss.fff")}");
            MeuEvento.DispararEvento();

            Console.WriteLine($"End: {DateTime.Now.ToString("HH:mm:ss.fff")}");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("teste")]
        public IEnumerable<WeatherForecast> GetTest()
        {
            var jobWrapper = new JobWrapper();

            // Subscribe to the JobCompleted event

            jobWrapper.StartJob();
            //Console.WriteLine($"Start: {DateTime.Now.ToString("HH:mm:ss.fff")}");
            //MeuEvento.DispararEvento();

            //Console.WriteLine($"End: {DateTime.Now.ToString("HH:mm:ss.fff")}");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}