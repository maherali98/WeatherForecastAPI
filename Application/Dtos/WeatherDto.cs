namespace Application.Dtos
{
    public class WeatherDto
    {
        public string City { get; set; } = string.Empty;
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; } = string.Empty;
    }

}
