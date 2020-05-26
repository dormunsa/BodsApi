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
        public async Task<List<Weather>> GetWeatherById(int weatherId)
        {
            return await weatherData.GetWeatherById(weatherId);
        }
        public async Task<List<Weather>> GetWeather()
        {
            return await weatherData.GetWeather();
        }

        public async Task<List<Weather>> GetWeatherByLocation(float latitude, float longitude)
        {
            return await weatherData.GetWeatherByLocation(latitude, longitude);
        }

        public async Task<ulong> InsertWeather(Weather weather)
        {
            return await weatherData.InsertWeather(weather);
        }
    }
}
