using BodsEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BodsLogic
{
    public class CameraLogic
    {
        public CameraLogic()
        {
            this.cameraCRUDService = new CameraCRUDService();
            Response = new BaseResponse();
            this.userCameraLogic = new UserCameraLogic();
            this.userCRUDService = new UserCRUDService();
        }

        public CameraCRUDService cameraCRUDService { get; set; }
        public BaseResponse Response  { get; set; }
        public UserCameraLogic userCameraLogic { get; set; }
        public UserCRUDService userCRUDService { get; set; }

        // Update camera working status
        public async Task<bool> ChangeWorkingStatus(int cameraId, string guid)
        {

            Response.IsSuccessful = true;
            // validate request values
            if (cameraId == 0 || string.IsNullOrEmpty(guid))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "you must provide camera Id and guid ";
                return false;
            }
            // get user by guid and validate user permision
            User user = await userCRUDService.GetByUserGuid(guid);
            if (user == null || user?.IsAdmin == false)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "user is not exist or user  is not admin";
                return false;
            }

            // get usercamera by camera id and validate camera is asigned to user
            UserCamera userCamera = await userCameraLogic.GetCameraById(cameraId);
            if (userCamera == null || (userCamera.UserId != user.UserId && userCamera.UserId != user.AdminId))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "camera is not exist or user  is own this camera";
                return false;
            }

            // get camera by id 
            Camera camera = await cameraCRUDService.GetCameraById(cameraId);
            if (camera == null)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "camera is not exist ";
                return false;
            }
            // update camera working status by existing value
            if (camera.IsWorking)
                return await cameraCRUDService.ChangeWorkingStatus(false, cameraId);
            return await cameraCRUDService.ChangeWorkingStatus( true , cameraId);
        }

        public async Task InsertCamera(UpdateCameraRequest request, string guid)
        {

            Response.IsSuccessful = true;
            // validate request values
            if (string.IsNullOrEmpty(request.LocationName) || request.Latitude == 0 || request.Longitude == 0 || string.IsNullOrEmpty(guid))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "you must provide all required fields ";
                return;
            }

            // get user by guid and validate user permision
            User user = await userCRUDService.GetByUserGuid(guid);
            if (user == null || user?.IsAdmin == false)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "user is not exist or user  is not admin";
                return ;
            }
            Camera newCamera = new Camera()
            {
                CameraId = 0,
                DateAdded = DateTime.UtcNow,
                IsWorking = request.IsWorking,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                LocationName = request.LocationName
            };
            // insert camera and get new camera id 
            int newId = (int) await cameraCRUDService.InsertCamera(newCamera);
            if (newId == 0)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "cannot insert camera";
                return;
            }
            // if camera inserted insert usercamera by new camera id value
            if (!await userCameraLogic.InsertUserCamera(user.UserId, newId))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "camera was inserted but userCamera faild";
                return;
            }
        }

        public async Task UpdateCamera(UpdateCameraRequest request, string guid)
        {

            Response.IsSuccessful = true;
            // validate request values
            if (request.CameraId == 0 || string.IsNullOrEmpty(guid))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "you must provide all required fields ";
                return;
            }
            // get user by guid and validate user permision
            User user = await userCRUDService.GetByUserGuid(guid);
            if (user == null || user?.IsAdmin == false)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "user is not exist or user  is not admin";
                return;
            }
            // get usercamera by camera id and validate camera is asigned to user
            UserCamera userCamera = await userCameraLogic.GetCameraById(request.CameraId);
            if (userCamera == null || (userCamera.UserId != user.UserId && userCamera.UserId != user.AdminId))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "camera is not exist or user  is own this camera";
                return;
            }
            Camera newCamera = new Camera()
            {
                CameraId = request.CameraId,
                DateAdded = DateTime.UtcNow,
                IsWorking = request.IsWorking,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                LocationName = request.LocationName
            };
            // update camera 
            if ( ! await cameraCRUDService.UpdateCamera(newCamera))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "cannot update camera";
                return;
            }

        }

        public async Task DeleteCamera(Camera request, string guid)
        {

            Response.IsSuccessful = true;
            // validate request values
            if (request.CameraId == 0 || string.IsNullOrEmpty(guid))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "you must provide all required fields ";
                return;
            }
            // get user by guid and validate user permision
            User user = await userCRUDService.GetByUserGuid(guid);
            if (user == null || user?.IsAdmin == false)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "user is not exist or user  is not admin";
                return;
            }
            // get usercamera by camera id and validate camera is asigned to user
            UserCamera userCamera = await userCameraLogic.GetCameraById(request.CameraId);
            if (userCamera == null || (userCamera.UserId != user.UserId && userCamera.UserId != user.AdminId))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "camera is not exist or user  is own this camera";
                return;
            }
            // delete camera 
            if (!await cameraCRUDService.DeleteCamera(request.CameraId))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "cannot Delete camera";
                return;
            }

        }

        public async Task<List<Camera>> GetAllUserCameras(string guid)
        {

            Response.IsSuccessful = true;
            // validate request values
            if ( string.IsNullOrEmpty(guid))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "you must provide guid ";
                return null;
            }
            // get user by guid 
            User user = await userCRUDService.GetByUserGuid(guid);
            if (user == null )
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "user is not exist or user  is not admin";
                return null;
            }
            // get user cameras by user id 
            List<UserCamera> userCameras = await userCameraLogic.GetByUserId(user.UserId);
            if (userCameras.Count == 0)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "this user is not have cameras";
                return null;
            }
            List<Camera> cameras = new List<Camera>();
            // get all cameras by camera id in foreach loop 
            foreach (UserCamera userCamera in userCameras)
            {
                Camera camera = await cameraCRUDService.GetCameraById(userCamera.CameraId);
                if (camera != null)
                    cameras.Add(camera);
            }

            if (cameras.Count == 0)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "this user is not have cameras";
                return null;
            }

            return cameras;

        }
        public async Task<int> GetCameraIdByLocation(double latitude, double longitude)
        {

            Response.IsSuccessful = true;
            // validate request values
            if (latitude == 0 || longitude == 0) 
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "you must provide latitude and longitude ";
                return 0;
            }
            // get camera by location values 
            Camera camera = await cameraCRUDService.GetCameraByLocation(latitude , longitude);
            if (camera == null)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "there is no camera at this location ";
                return 0;
            }

            return camera.CameraId;

        }


    }

   


}
