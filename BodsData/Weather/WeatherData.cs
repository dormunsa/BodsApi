using BodsEntity;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodsData
{
    public class WeatherData
    {
        public async Task<List<Weather>> GetWeatherById(int weatherId)
        {
            DynamicParameters _params = new DynamicParameters();

            _params.Add("@WeatherId", weatherId);

            string sql = " SELECT * FROM  " + bods.bods.Tweather
                            + " WHERE " + bods.bods.Tweather.FWeatherId.Cn + " =@WeatherId";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return (await conn.QueryAsync<Weather>(sql, _params)).ToList();
            }

        }

        public async Task<List<Weather>> GetWeather()
        {
            DynamicParameters _params = new DynamicParameters();

            string sql = " SELECT * FROM  " + bods.bods.Tweather ;

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return (await conn.QueryAsync<Weather>(sql, _params)).ToList();
            }

        }

        public async Task<List<Weather>> GetWeatherByLocation(float latitude, float longitude)
        {
            DynamicParameters _params = new DynamicParameters();

            _params.Add("@Latitude", latitude);
            _params.Add("@Longitude", longitude);

            string sql = " SELECT * FROM  " + bods.bods.Tweather
                            + " WHERE " + bods.bods.Tweather.FLatitude.Cn + " =@Latitude"
                            + " AND " + bods.bods.Tweather.FLongitude.Cn + " =@Longitude";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return (await conn.QueryAsync<Weather>(sql, _params)).ToList();
            }

        }

        public async Task<ulong> InsertWeather(Weather weather)
        {
            DynamicParameters _params = new DynamicParameters();

            _params.Add("@Latitude", weather.Latitude);
            _params.Add("@Longitude", weather.Longitude);
            _params.Add("@LocationName", weather.LocationName);
            _params.Add("@WindSpeed", weather.WindSpeed);
            _params.Add("@Date", weather.Date);
            _params.Add("@Description", weather.Description);


            string sql = " INSERT INTO  " + bods.bods.Tweather
                                     + "    (" + bods.bods.Tweather.FLatitude.Cn
                                     + "    ," + bods.bods.Tweather.FLongitude.Cn
                                     + "    ," + bods.bods.Tweather.FLocationName.Cn
                                     + "    ," + bods.bods.Tweather.FWindSpeed.Cn
                                     + "    ," + bods.bods.Tweather.FDate.Cn
                                     + "    ," + bods.bods.Tweather.FDescription.Cn
                                     + ")"
                                     + " VALUES"
                                     + " (@Latitude"
                                     + " ,@Longitude"
                                     + " ,@LocationName"
                                     + " ,@WindSpeed"
                                     + " ,@Date"
                                     + " ,@Description"
                                     + ");";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                Convert.ToBoolean(await conn.ExecuteAsync(sql, _params));
                var id = conn.Query<ulong>("SELECT CAST(LAST_INSERT_ID() AS UNSIGNED INTEGER);").Single();
                return id;
            }

        }
    }
}
