using BodsData;
using BodsEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BodsLogic
{
    public class CameraCRUDService
    {
        public CameraCRUDService()
        {
            this.cameraData = new CameraData();
        }

        public CameraData cameraData { get; set; }
        public async Task<Camera> GetCameraById(int cameraId)
        {
            return await cameraData.GetCameraById(cameraId);
        }

        public async Task<bool> UpdateCamera(Camera camera)
        {
            return await cameraData.UpdateCamera(camera);
        }

        public async Task<ulong> InsertCamera(Camera camera)
        {
            return await cameraData.InsertCamera(camera);
        }

        public async Task<bool> DeleteCamera(int cameraId)
        {
            return await cameraData.DeleteCamera(cameraId);
        }

        public async Task<bool> ChangeWorkingStatus(bool isWorking, int cameraId)
        {
            return await cameraData.ChangeWorkingStatus(isWorking , cameraId);
        }
        public async Task<Camera> GetCameraByLocation(double latitude, double longitude)
        {
            return await cameraData.GetCameraByLocation( latitude,  longitude);
        }

    }
}
