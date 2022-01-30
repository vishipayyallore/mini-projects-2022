using HeaderFooter.Lib.Interfaces;
using WeatherUtility.Core.Entities;
using WeatherUtility.Core.Interfaces;

using static System.Console;

namespace WeatherUtility.Run
{

    public class WeatherUtilityApp
    {

        private readonly IHeader _header;
        private readonly IFooter _footer;
        private readonly ITemperatureConvertor _temperatureConvertor;
        private readonly IWeatherReport _weatherReport;

        // Prefilling with Dummy data
        private IList<WeatherData> WeatherDatas { get; set; } = GetWeatherData();

        public WeatherUtilityApp(IHeader header, IFooter footer, ITemperatureConvertor temperatureConvertor, IWeatherReport weatherReport)
        {
            _header = header ?? throw new ArgumentNullException(nameof(header));
            _footer = footer ?? throw new ArgumentNullException(nameof(footer));

            _temperatureConvertor = temperatureConvertor ?? throw new ArgumentNullException(nameof(temperatureConvertor));
            _weatherReport = weatherReport ?? throw new ArgumentNullException(nameof(weatherReport));
        }

        // Application starting point
        public void Run()
        {
            ShowWeatherConversion();

            ShowWeatherReport();
        }

        private void ShowWeatherConversion()
        {
            float fahrenheit = 65;

            _header.DisplayHeader('*', "Weather Conversions");

            var celsius = _temperatureConvertor.FahrenheitToCelsius(fahrenheit);
            WriteLine($"{fahrenheit}°F equals {celsius}°C");

            fahrenheit = _temperatureConvertor.CelsiusToFahrenheit(celsius);
            WriteLine($"{celsius}°C equals {fahrenheit}°F");

            _footer.DisplayFooter('-');
        }

        private void ShowWeatherReport()
        {
            _header.DisplayHeader('=', "Weather Report");

            foreach (var weatherData in WeatherDatas)
            {
                _weatherReport.DisplayReport(weatherData);
            }

            _footer.DisplayFooter('-');
        }

        // TODO: Get this data from SQLite
        private static IList<WeatherData> GetWeatherData() => new List<WeatherData>
            {
                new WeatherData { Location= "San Francisco", TemperatureCelsius = 19, Humidity = 73 },
                new WeatherData { Location = "Denver", TemperatureCelsius = 21, Humidity = 55},
                new WeatherData { Location = "Bologna", TemperatureCelsius = 23, Humidity= 65 },
                new WeatherData { Location = "Hyderabad", TemperatureCelsius = 35, Humidity= 65 }
            };
    }

}
