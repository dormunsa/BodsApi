using BodsData;
using BodsEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BodsLogic
{
    //this class is middleware from logic to data layer
    public class CameraCRUDService
    {
        public CameraCRUDService()
        {
            this.cameraData = new CameraData();
        }

        public CameraData cameraData { get; set; }

        // get camera by camera id 
        public async Task<Camera> GetCameraById(int cameraId)
        {
            return await cameraData.GetCameraById(cameraId);
        }
        // Update camera details by camera Id
        public async Task<bool> UpdateCamera(Camera camera)
        {
            return await cameraData.UpdateCamera(camera);
        }
        // Insert camera 
        public async Task<int> InsertCamera(Camera camera)
        {
            return await cameraData.InsertCamera(camera);
        }
        // Delete camera
        public async Task<bool> DeleteCamera(int cameraId)
        {
            return await cameraData.DeleteCamera(cameraId);
        }
        // Update camera working status
        public async Task<bool> ChangeWorkingStatus(bool isWorking, int cameraId)
        {
            return await cameraData.ChangeWorkingStatus(isWorking , cameraId);
        }
        // get camera by location values
        public async Task<Camera> GetCameraByLocation(double latitude, double longitude)
        {
            return await cameraData.GetCameraByLocation( latitude,  longitude);
        }

    }
}
