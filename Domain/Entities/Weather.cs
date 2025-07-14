namespace Domain.Entities;

public class Weather
{
    public string City { get; set; } = string.Empty;
    public int TemperatureCelsius { get; set; }
    public string Summary { get; set; } = string.Empty;
}