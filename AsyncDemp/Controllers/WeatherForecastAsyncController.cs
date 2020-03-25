using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AsyncDemp.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastAsyncController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastAsyncController> _logger;

		public WeatherForecastAsyncController(ILogger<WeatherForecastAsyncController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public async Task<IEnumerable<WeatherForecast>> Get()
		{
			return await GetWeatherForcasts();
		}

		async Task <IEnumerable<WeatherForecast>> GetWeatherForcasts()
		{
			await Task.Delay(400);
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}

