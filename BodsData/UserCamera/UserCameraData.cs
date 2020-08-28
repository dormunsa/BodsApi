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
    // responsible for all the queries to usercamera table at DB
    public class UserCameraData
    {
        // get camera by camera id values query
        public async Task<UserCamera> GetCameraById(int cameraId)
        {
            DynamicParameters _params = new DynamicParameters();

            _params.Add("@CameraId", cameraId);

            string sql = " SELECT * FROM  " + bods.bods.Tusercamera
                            + " WHERE " + bods.bods.Tusercamera.FCameraId.Cn + " =@CameraId";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return (await conn.QueryAsync<UserCamera>(sql, _params)).ToList().FirstOrDefault();
            }

        }

        // get list by user id  query
        public async Task<List<UserCamera>> GetByUserId(int userId)
        {
            DynamicParameters _params = new DynamicParameters();

            _params.Add("@UserId", userId);

            string sql = " SELECT * FROM  " + bods.bods.Tusercamera
                            + " WHERE " + bods.bods.Tusercamera.FUserId.Cn + " =@UserId";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return (await conn.QueryAsync<UserCamera>(sql, _params)).ToList();
            }

        }

        // get list by user id and camera id   query
        public async Task<UserCamera> GetByUserIdAndCameraId(int userId , int cameraId)
        {
            DynamicParameters _params = new DynamicParameters();

            _params.Add("@UserId", userId);
            _params.Add("@CameraId", cameraId);

            string sql = " SELECT * FROM  " + bods.bods.Tusercamera
                            + " WHERE " + bods.bods.Tusercamera.FUserId.Cn + " =@UserId"
                            + " AND " + bods.bods.Tusercamera.FCameraId.Cn + " =@CameraId";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return (await conn.QueryAsync<UserCamera>(sql, _params)).ToList().FirstOrDefault();
            }

        }

        // update user id  query
        public async Task<bool> UpdateUserId(int userId, int cameraId)
        {
            DynamicParameters _params = new DynamicParameters();
            _params.Add("@UserId", userId);
            _params.Add("@CameraId", cameraId);


            string sql = " UPDATE" + bods.bods.Tusercamera + " SET "
                                       + bods.bods.Tusercamera.FUserId.Cn + " =@UserId"
                                       + " WHERE " + bods.bods.Tusercamera.FCameraId.Cn + " =@CameraId ";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return Convert.ToBoolean(await conn.ExecuteAsync(sql, _params));
            }

        }

        // insert usercamera   query
        public async Task<bool> InsertUserCamera(int userId, int cameraId)
        {
            DynamicParameters _params = new DynamicParameters();
            _params.Add("@UserId", userId);
            _params.Add("@CameraId", cameraId);


            string sql = " INSERT INTO " + bods.bods.Tusercamera
                                     + "    (" + bods.bods.Tusercamera.FUserId.Cn
                                     + "    ," + bods.bods.Tusercamera.FCameraId.Cn
                                     + ")"
                                     + " VALUES"
                                     + " (@UserId"
                                     + " ,@CameraId"
                                     + ");";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return Convert.ToBoolean(await conn.ExecuteAsync(sql, _params));
            }

        }

        // delete usercamera query
        public async Task<bool> DeleteUserCamera(int userId, int cameraId)
        {
            DynamicParameters _params = new DynamicParameters();
            _params.Add("@UserId", userId);
            _params.Add("@CameraId", cameraId);


            string sql = " DELETE FROM  " + bods.bods.Tusercamera
                              + " WHERE " + bods.bods.Tusercamera.FUserId.Cn + " =@UserId"
                              + " AND " + bods.bods.Tusercamera.FCameraId.Cn + " =@CameraId";

            using (IDbConnection conn = DataLayer.NewConnection())
            {
                return Convert.ToBoolean(await conn.ExecuteAsync(sql, _params));
            }

        }
    }
}
