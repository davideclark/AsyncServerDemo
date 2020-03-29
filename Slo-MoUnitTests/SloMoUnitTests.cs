using AsyncDemp.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Slo_Mo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Slo_MoUnitTests
{
	public class SloMoUnitTests
	{
		[Fact]
		public async Task GetWeatherForcastReturnsForcasts()
		{
			Mock<ILogger<WeatherForecastAsyncController>> loggerMock = new Mock<ILogger<WeatherForecastAsyncController>>();

			WeatherForecastAsyncController weatherForecastAsyncController = new WeatherForecastAsyncController(
				loggerMock.Object);

			int delay = 0;

			IEnumerable<WeatherForecast> result = await weatherForecastAsyncController.Get(delay);

			Assert.NotNull(result);


		}
	}
}
