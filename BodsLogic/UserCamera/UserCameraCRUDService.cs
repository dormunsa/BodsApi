using BodsData;
using BodsEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BodsLogic
{
    public class UserCameraCRUDService
    {
        public UserCameraCRUDService()
        {
            this.userCameraData = new UserCameraData();
        }

        public UserCameraData userCameraData { get; set; }
        // get camera by camera id value 
        public async Task<UserCamera> GetCameraById(int cameraId)
        {
            return await userCameraData.GetCameraById(cameraId);
        }
        // get list by user id
        public async Task<List<UserCamera>> GetByUserId(int userId)
        {
            return await userCameraData.GetByUserId(userId);
        }
        // get list by user id and camera id
        public async Task<UserCamera> GetByUserIdAndCameraId(int userId, int cameraId)
        {
            return await userCameraData.GetByUserIdAndCameraId(userId , cameraId);
        }
        // update user id
        public async Task<bool> UpdateUserId(int userId, int cameraId)
        {
            return await userCameraData.UpdateUserId(userId, cameraId);
        }
        // insert usercamera
        public async Task<bool> InsertUserCamera(int userId, int cameraId)
        {
            return await userCameraData.InsertUserCamera(userId, cameraId);
        }
        // delete usercamera
        public async Task<bool> DeleteUserCamera(int userId, int cameraId)
        {
            return await userCameraData.DeleteUserCamera(userId, cameraId);
        }

    }
}
