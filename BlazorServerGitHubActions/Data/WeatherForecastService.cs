using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerGitHubActions.Data
{
    public class WeatherForecastService
    {
        private readonly IConfiguration _configuration;

        public WeatherForecastService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var appSetting = _configuration.GetValue<string>("AppSettingValue");
            var gitHub = _configuration.GetValue<string>("GitHubSecretValue");

            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                //Summary = Summaries[rng.Next(Summaries.Length)
                Summary = $"[{appSetting}][{gitHub}]"
            }).ToArray());
        }
    }
}