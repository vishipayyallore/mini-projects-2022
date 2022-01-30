// See https://aka.ms/new-console-template for more information
using HeaderFooter.Lib;
using HeaderFooter.Lib.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using WeatherUtility.Core.Interfaces;
using WeatherUtility.Lib;
using WeatherUtility.Run;

using static System.Console;

// create service collection
var services = ConfigureServices();

// Generate a provider
var serviceProvider = services.BuildServiceProvider();

// Kick off the actual code
serviceProvider?.GetService<WeatherUtilityApp>()?.Run();

WriteLine("\n\nPress any key ...");
ReadKey();


static IServiceCollection ConfigureServices()
{
    IServiceCollection services = new ServiceCollection();

    services.AddTransient<ITemperatureConvertor, TemperatureConvertor>();
    services.AddTransient<ITemperatureUtility, TemperatureUtility>();
    services.AddTransient<IWeatherReport, WeatherReport>();

    // Header Footer
    services.AddTransient<IHeader, Header>();
    services.AddTransient<IFooter, Footer>();

    // IMPORTANT! Register the application entry point
    services.AddTransient<WeatherUtilityApp>();

    return services;
}