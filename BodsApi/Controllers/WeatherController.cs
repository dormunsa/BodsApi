using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BodsApi.ActionFilters;
using BodsEntity;
using BodsLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BodsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> InsertWeather([FromBody]InsertWeatherRequest request)
        {
            WeatherLogic weatherLogic = new WeatherLogic();
            int id = await weatherLogic.InsertWeather(request);
            if (id == 0)
                return BadRequest(weatherLogic.Response.ErrorMessage);
            return Ok(id);
        }
        [HttpGet]
        public async Task<IActionResult> GetWeather([FromQuery]int weatherId =0 , float latitude =0 , float longitude = 0)
        {

            WeatherLogic weatherLogic = new WeatherLogic();
            List<Weather> weathers = await weatherLogic.GetWeather(weatherId , latitude, longitude);
            if (weathers == null)
                return BadRequest(weatherLogic.Response.ErrorMessage);
            return Ok(weathers);
        }
    }
}