using Microsoft.AspNetCore.Mvc;
using TaskTrackerBackend.Services;

namespace tasktrackerBackEnd.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly WeatherForecastService _data;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherForecastService data)
    {
        _logger = logger;
        _data = data;

    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return _data.GetWeather(Summaries);
    }
}
