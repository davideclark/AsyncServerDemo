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
    public class DemoController : Controller
    {
		[HttpGet]
		public string Get([FromQuery]int delay)
		{
			HttpResponseMessage response;
			HttpClient httpClient = new HttpClient();
			try
			{
				response = httpClient.GetAsync(@"https://slo-mo.azurewebsites.net/WeatherForecastAsync?delay=" + delay).Result;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
				Console.WriteLine(ex.Message);
				return "Http error " + ex.Message;
			}

			return response.Content.ReadAsStringAsync().Result;
		}
	}
}