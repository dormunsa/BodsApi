using BodsData;
using BodsEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BodsLogic
{
    public class WeatherCRUDService
    {
        public WeatherCRUDService()
        {
            this.weatherData = new WeatherData();
        }

        public WeatherData weatherData { get; set; }
        // get weather by weather id value
        public async Task<List<Weather>> GetWeatherById(int weatherId)
        {
            return await weatherData.GetWeatherById(weatherId);
        }
        // get all weather
        public async Task<List<Weather>> GetWeather()
        {
            return await weatherData.GetWeather();
        }
        // get weather by location values
        public async Task<List<Weather>> GetWeatherByLocation(float latitude, float longitude)
        {
            return await weatherData.GetWeatherByLocation(latitude, longitude);
        }
        // insert weather
        public async Task<ulong> InsertWeather(Weather weather)
        {
            return await weatherData.InsertWeather(weather);
        }
    }
}
