using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;


public class WeatherService : IWeatherService
{
    private readonly IMemoryCache _cache;

    public WeatherService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public Task<WeatherDto> GetWeatherAsync(string city)
    {

        if (_cache.TryGetValue(city.ToLower(), out WeatherDto weather))
        {
            return Task.FromResult(weather);
        }
        var summaries = new[]
        {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        weather = new WeatherDto
        {
            City = city,
            TemperatureCelsius = Random.Shared.Next(-10, 40),
            Summary = summaries[Random.Shared.Next(summaries.Length)]
        };

        _cache.Set(city.ToLower(), weather, TimeSpan.FromMinutes(10));
        return Task.FromResult(weather);
    }


}
