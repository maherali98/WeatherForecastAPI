using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/weather")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Get([FromQuery] string city)
    {
        var weather = await _weatherService.GetWeatherAsync(city);
        return Ok(weather);
    }
}
