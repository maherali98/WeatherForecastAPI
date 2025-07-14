using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces;

public interface IWeatherService
{
    Task<WeatherDto> GetWeatherAsync(string city);
}