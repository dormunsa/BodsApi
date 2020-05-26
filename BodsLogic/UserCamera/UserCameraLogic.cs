using BodsEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BodsLogic
{
    public class UserCameraLogic
    {
        public UserCameraLogic()
        {
            this.userCameraCRUDService = new UserCameraCRUDService();
        }

        public UserCameraCRUDService userCameraCRUDService { get; set; }

        public async Task<UserCamera> GetCameraById(int cameraId)
        {
            return await userCameraCRUDService.GetCameraById(cameraId);
        }

        public async Task<List<UserCamera>> GetByUserId(int userId)
        {
            return await userCameraCRUDService.GetByUserId(userId);
        }
        public async Task<UserCamera> GetByUserIdAndCameraId(int userId, int cameraId)
        {
            return await userCameraCRUDService.GetByUserIdAndCameraId(userId, cameraId);
        }
        public async Task<bool> UpdateUserId(int userId, int cameraId)
        {
            return await userCameraCRUDService.UpdateUserId(userId, cameraId);
        }
        public async Task<bool> InsertUserCamera(int userId, int cameraId)
        {
            return await userCameraCRUDService.InsertUserCamera(userId, cameraId);
        }
        public async Task<bool> DeleteUserCamera(int userId, int cameraId)
        {
            return await userCameraCRUDService.DeleteUserCamera(userId, cameraId);
        }
    }
}
