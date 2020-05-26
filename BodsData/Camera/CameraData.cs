﻿using BodsEntity;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodsData
{
    public class CameraData
    {
        public async Task<Camera> GetCameraById(int cameraId)
        {
            DynamicParameters _params = new DynamicParameters();

            _params.Add("@CameraId", cameraId);

            string sql = " SELECT * FROM  " + bods.bods.Tcamera
                            + " WHERE " + bods.bods.Tcamera.FCameraId.Cn + " =@CameraId";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return (await conn.QueryAsync<Camera>(sql, _params)).ToList().FirstOrDefault();
            }

        }

        public async Task<Camera> GetCameraByLocation(double latitude , double longitude )
        {
            DynamicParameters _params = new DynamicParameters();

            _params.Add("@Latitude", latitude);
            _params.Add("@Longitude", longitude);

            string sql = " SELECT * FROM  " + bods.bods.Tcamera
                            + " WHERE " + bods.bods.Tcamera.FLatitude.Cn + " LIKE @Latitude"
                            + " AND " + bods.bods.Tcamera.FLongitude.Cn + " LIKE @Longitude";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return (await conn.QueryAsync<Camera>(sql, _params)).ToList().FirstOrDefault();
            }

        }

        public async Task<bool> UpdateCamera(Camera camera)
        {
            DynamicParameters _params = new DynamicParameters();

            _params.Add("@CameraId", camera.CameraId);
            _params.Add("@Latitude", camera.Latitude);
            _params.Add("@Longitude", camera.Longitude);
            _params.Add("@LocationName", camera.LocationName);

            string sql = " UPDATE  " + bods.bods.Tcamera + " SET "
                            + bods.bods.Tcamera.FLatitude.Cn + " =@Latitude, "
                            + bods.bods.Tcamera.FLongitude.Cn + " =@Longitude, "
                            + bods.bods.Tcamera.FLocationName.Cn + " =@LocationName "
                            + " WHERE " + bods.bods.Tcamera.FCameraId.Cn + " =@CameraId";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return Convert.ToBoolean(await conn.ExecuteAsync(sql, _params));
            }

        }

        public async Task<bool> ChangeWorkingStatus(bool isWorking , int cameraId)
        {
            DynamicParameters _params = new DynamicParameters();

            _params.Add("@IsWorking", isWorking);
            _params.Add("@CameraId", cameraId);
         
            string sql = " UPDATE  " + bods.bods.Tcamera + " SET "
                            + bods.bods.Tcamera.FIsWorking.Cn + " =@IsWorking "
                            + " WHERE " + bods.bods.Tcamera.FCameraId.Cn + " =@CameraId";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return Convert.ToBoolean(await conn.ExecuteAsync(sql, _params));
            }

        }

        public async Task<ulong> InsertCamera(Camera camera)
        {
            DynamicParameters _params = new DynamicParameters();

           
            _params.Add("@Latitude", camera.Latitude);
            _params.Add("@Longitude", camera.Longitude);
            _params.Add("@LocationName", camera.LocationName);
            _params.Add("@IsWorking", camera.IsWorking);
            _params.Add("@DateAdded", camera.DateAdded);

            string sql = " INSERT INTO  " + bods.bods.Tcamera
                                     + "    (" + bods.bods.Tcamera.FLatitude.Cn
                                     + "    ," + bods.bods.Tcamera.FLongitude.Cn
                                     + "    ," + bods.bods.Tcamera.FLocationName.Cn
                                     + "    ," + bods.bods.Tcamera.FIsWorking.Cn
                                     + "    ," + bods.bods.Tcamera.FDateAdded.Cn
                                     + ")"
                                     + " VALUES"
                                     + " (@Latitude"
                                     + " ,@Longitude"
                                     + " ,@LocationName"
                                     + " ,@IsWorking"
                                     + " ,@DateAdded"
                                     + ");";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                 Convert.ToBoolean(await conn.ExecuteAsync(sql, _params));
                 var id = conn.Query<ulong>("SELECT CAST(LAST_INSERT_ID() AS UNSIGNED INTEGER);").Single();
                 return id;
            }

        }

        public async Task<bool> DeleteCamera(int cameraId)
        {
            DynamicParameters _params = new DynamicParameters();
            _params.Add("@CameraId", cameraId);

            string sql = " DELETE FROM  " + bods.bods.Tcamera
                                     + "  WHERE " + bods.bods.Tcamera.FCameraId.Cn + " =@CameraId";
                                 
            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return Convert.ToBoolean(await conn.ExecuteAsync(sql, _params));
            }

        }
    }
}
