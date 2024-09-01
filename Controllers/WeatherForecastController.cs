using Microsoft.AspNetCore.Mvc;

namespace API_for_react.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [Produces("application/json")]
        [HttpGet("GetData")]
        public IActionResult GetData(string? request)
        {
            /*if(request != 0)
            {
                var math = Math.Sqrt(request);
                var str = math.GetType() != double ? "erg" : "erf";
            }
            */

            if(request != null)
            {
                var lenght = request.Length;
                var state = lenght > 5 ? "Хорошая длина" : "Добавьте еще символов!";

                var data = new { Data = request, State = state, length = lenght };
                return new JsonResult(data);
            }
            return BadRequest();
        }
    }
}
