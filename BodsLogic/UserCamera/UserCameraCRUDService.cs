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

        public async Task<UserCamera> GetCameraById(int cameraId)
        {
            return await userCameraData.GetCameraById(cameraId);
        }

        public async Task<List<UserCamera>> GetByUserId(int userId)
        {
            return await userCameraData.GetByUserId(userId);
        }
        public async Task<UserCamera> GetByUserIdAndCameraId(int userId, int cameraId)
        {
            return await userCameraData.GetByUserIdAndCameraId(userId , cameraId);
        }
        public async Task<bool> UpdateUserId(int userId, int cameraId)
        {
            return await userCameraData.UpdateUserId(userId, cameraId);
        }
        public async Task<bool> InsertUserCamera(int userId, int cameraId)
        {
            return await userCameraData.InsertUserCamera(userId, cameraId);
        }
        public async Task<bool> DeleteUserCamera(int userId, int cameraId)
        {
            return await userCameraData.DeleteUserCamera(userId, cameraId);
        }

    }
}
