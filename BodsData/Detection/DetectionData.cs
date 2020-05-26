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
    public class DetectionData
    {
        public async Task<List<Detection>> GetDetection(int detectionId)
        {
            DynamicParameters _params = new DynamicParameters();

            _params.Add("@DetectionId", detectionId);

            string sql = " SELECT * FROM  " + bods.bods.Tdetection;
            if (detectionId != 0)
                sql += " WHERE " + bods.bods.Tdetection.FDetectionId.Cn + " =@DetectionId";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return (await conn.QueryAsync<Detection>(sql, _params)).ToList();
            }

        }

        public async Task<List<Detection>> GetDetectionByCameraId(int cameraId)
        {
            DynamicParameters _params = new DynamicParameters();

            _params.Add("@CameraId", cameraId);

            string sql = " SELECT * FROM  " + bods.bods.Tdetection
                        + " WHERE " + bods.bods.Tdetection.FCameraId.Cn + " =@CameraId";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return (await conn.QueryAsync<Detection>(sql, _params)).ToList();
            }

        }



        public async Task<bool> InsertDetection(Detection detection)
        {
            DynamicParameters _params = new DynamicParameters();

            _params.Add("@WeatherId", detection.WeatherId);
            _params.Add("@CameraId", detection.CameraId);
            _params.Add("@ImagePath", detection.ImagePath);
            _params.Add("@Date", detection.Date);
            
            string sql = " INSERT INTO  " + bods.bods.Tdetection
                                     + "    (" + bods.bods.Tdetection.FWeatherId.Cn
                                     + "    ," + bods.bods.Tdetection.FCameraId.Cn
                                     + "    ," + bods.bods.Tdetection.FImagePath.Cn
                                     + "    ," + bods.bods.Tdetection.FDate.Cn  
                                     + ")"
                                     + " VALUES"
                                     + " (@WeatherId"
                                     + " ,@CameraId"
                                     + " ,@ImagePath"
                                     + " ,@Date"
                                     + ");";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return Convert.ToBoolean(await conn.ExecuteAsync(sql, _params));
            }

        }

        public async Task<List<DetectionResponse>> ReadDetection(DateTime fromDate, DateTime toDate , int cameraId)
        {

            DynamicParameters _params = new DynamicParameters();
            _params.Add("@ToDate", toDate);
            _params.Add("@FromDate", fromDate);
            _params.Add("@CameraId", cameraId);

            string sql = " SELECT " + bods.bods.Tdetection + ".*, " + bods.bods.Tweather + ".*, " + bods.bods.Tcamera + ".* "
                         + " FROM " + bods.bods.Tdetection
                         + " LEFT JOIN " + bods.bods.Tweather + " ON " + bods.bods.Tweather.FWeatherId.Cn + " = " + bods.bods.Tdetection.FWeatherId.Cn
                         + " LEFT JOIN " + bods.bods.Tcamera + " ON " + bods.bods.Tcamera.FCameraId.Cn + " = " + bods.bods.Tdetection.FCameraId.Cn
                         + " WHERE " + bods.bods.Tdetection.FDate.Cn + " >=@FromDate"
                         + " AND " + bods.bods.Tdetection.FDate.Cn + " <=@ToDate"
                         + " AND " + bods.bods.Tdetection.FCameraId.Cn + " =@CameraId";
            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return (await conn.QueryAsync<DetectionResponse>(sql,
                new[] {
                    typeof(int), //  0  DetectionId
                    typeof(int), // 1  CameraId
                    typeof(string), // 2  ImagePath
                    typeof(int), // 3 WeatherId
                    typeof(DateTime), // 4 Date
                    typeof(int), // 5 WeatherId
                    typeof(string), // 6 WeatherlocationName
                    typeof(double), // 7 Longitude
                    typeof(double), // 8 Latitude
                    typeof(DateTime), // 9 Date
                    typeof(double), // 10 WindSpeed
                    typeof(string), // 11 Description
                    typeof(int), // 12 CameraId
                    typeof(string), // 13 CameraLocationName
                    typeof(double), // 14 Longitude
                    typeof(double), // 15 Latitude
                    typeof(bool), // 16 IsWorking
                    typeof(DateTime) // 17 DateAdded             
                }, objects =>
                {
                    DetectionResponse detectionResponse = new DetectionResponse()
                    {
                        CameraId = objects[1] as int? ?? 0,
                        ImagePath = objects[2] as string,
                        Date = objects[4] as DateTime? ?? DateTime.UtcNow,
                        WeatherLocationName = objects[6] as string,
                        Longitude = objects[7] as double? ?? 0,
                        Latitude = objects[8] as double? ?? 0,
                        WindSpeed = objects[10] as double? ?? 0,
                        Description = objects[11] as string,
                        CameraLocationName = objects[13] as string

                    };


                    return detectionResponse;
                }
                , _params
                , splitOn: $@"{bods.bods.Tdetection.FCameraId.OnlyColumnName},
                                 {bods.bods.Tdetection.FImagePath.OnlyColumnName},
                                 {bods.bods.Tdetection.FWeatherId.OnlyColumnName},
                                 {bods.bods.Tdetection.FDate.OnlyColumnName},
                                 {bods.bods.Tweather.FWeatherId.OnlyColumnName},
                                 {bods.bods.Tweather.FLocationName.OnlyColumnName},
                                 {bods.bods.Tweather.FLongitude.OnlyColumnName},
                                 {bods.bods.Tweather.FLatitude.OnlyColumnName},
                                 {bods.bods.Tweather.FDate.OnlyColumnName},
                                 {bods.bods.Tweather.FWindSpeed.OnlyColumnName},
                                 {bods.bods.Tweather.FDescription.OnlyColumnName},
                                 {bods.bods.Tcamera.FCameraId.OnlyColumnName},
                                 {bods.bods.Tcamera.FLocationName.OnlyColumnName},
                                 {bods.bods.Tcamera.FLongitude.OnlyColumnName},
                                 {bods.bods.Tcamera.FLatitude.OnlyColumnName},
                                 {bods.bods.Tcamera.FIsWorking.OnlyColumnName},
                                 {bods.bods.Tcamera.FDateAdded.OnlyColumnName}"
                              )).ToList();
            }

        }


    }
}
