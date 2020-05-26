using BodsEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BodsLogic
{
    public class WeatherLogic
    {
        public WeatherLogic()
        {
            this.weatherCRUDService = new WeatherCRUDService();
            Response = new BaseResponse();
        }

        public WeatherCRUDService weatherCRUDService { get; set; }
        public BaseResponse Response { get; set; }

        public async Task<List<Weather>> GetWeather(int weatherId, float latitude, float longitude)
        {
            if (latitude != 0 && longitude != 0)
                return await weatherCRUDService.GetWeatherByLocation(latitude, longitude);
            if (weatherId != 0)
                return await weatherCRUDService.GetWeatherById(weatherId);
            return await weatherCRUDService.GetWeather();
        }

        public async Task<int> InsertWeather(InsertWeatherRequest request)
        {
            if (request.Latitude == 0 || request.Longitude == 0 || request.WindSpeed == 0)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "You Must provide Latitude Longitude WindSpeed";
                return 0;
            }
            Weather weather = new Weather()
            {
                WeatherId = 0 ,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                LocationName = request.LocationName,
                Date = DateTime.UtcNow,
                Description = request.Description,
                WindSpeed = request.WindSpeed
            };
            int newId = (int) await weatherCRUDService.InsertWeather(weather);
            if (newId == 0)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Cannot Insert Weather";
                return 0;
            }

            return newId;
              
        }
    }
}
