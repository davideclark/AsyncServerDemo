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
		public async Task<string> Get()
		{
			HttpClient httpClient = new HttpClient();
			
			var result = await httpClient.GetAsync(@"https://localhost:44343/weatherforecastasync");

			return await result.Content.ReadAsStringAsync();
		}
	}
}