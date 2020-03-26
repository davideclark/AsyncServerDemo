using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AsyncDemp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoAsyncController : Controller
    {
		[HttpGet]
		public async Task<string> Get([FromQuery] int delay)
		{
			HttpClient httpClient = new HttpClient();
			
			var result = await httpClient.GetAsync(@"https://slo-mo.azurewebsites.net/WeatherForecastAsync?delay=" + delay);

			return await result.Content.ReadAsStringAsync();
		}
	}
}