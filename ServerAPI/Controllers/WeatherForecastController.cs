using Core;
using Microsoft.AspNetCore.Mvc;


namespace ServerAPI.Controllers;

[ApiController]
[Route("vejr")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static readonly string[] location = new[]
    {
        "London", "New Orleans", "Aarhus", "Beirut", "South Australia", "Los Angeles", "South Mexico"
    };

    [HttpGet ("random/{count}")]
    
    public IEnumerable<WeatherForecast> Get(int count)
    {
        return Enumerable.Range(1, count).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                locations = location[Random.Shared.Next(location.Length)]
            })
            .ToArray();
    }
    
}