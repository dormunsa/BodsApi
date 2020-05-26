using BodsEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BodsLogic
{
    public class DetectionLogic
    {
        public DetectionLogic()
        {
            detectionCRUDService = new DetectionCRUDService();
            Response = new BaseResponse();
            userCRUDService = new UserCRUDService();
            userCameraLogic = new UserCameraLogic();
        }

        public DetectionCRUDService detectionCRUDService { get; set; }
        public UserCRUDService userCRUDService { get; set; }
        public BaseResponse Response { get; set; }
        public UserCameraLogic userCameraLogic { get; set; }

        public async Task<List<Detection>> GetDetection(int detectionId)
        {  
            return await detectionCRUDService.GetDetection(detectionId);
        }

        public async Task<List<Detection>> GetByUserGuid(string guid)
        {
            if (string.IsNullOrEmpty(guid))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Bad Request";
                return null;
            }
            User user = await userCRUDService.GetByUserGuid(guid);
            if (user == null || user?.UserId == 0)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "user is not exist ";
                return null;
            }
            List<UserCamera> userCameras = await userCameraLogic.GetByUserId(user.UserId);
            if (userCameras.Count == 0)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "no detections";
                return null;
            }
            List<Detection> detections = new List<Detection>();
            foreach (UserCamera userCamera in userCameras)
            {
                detections.AddRange(await detectionCRUDService.GetDetectionByCameraId(userCamera.CameraId));
            }
            return detections;
        }
        public async Task<List<DetectionResponse>> ReadDetection(DateTime fromDate, DateTime toDate , string guid)
        {
            if (fromDate == null || toDate == null || string.IsNullOrEmpty(guid))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Bad Request";
                return null;
            }
            User user = await userCRUDService.GetByUserGuid(guid);
            if (user == null || user?.UserId == 0)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "user is not exist ";
                return null;
            }
            List<UserCamera> userCameras = await userCameraLogic.GetByUserId(user.UserId);
            if (userCameras.Count == 0)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "no detections";
                return null;
            }
            List<DetectionResponse> detections = new List<DetectionResponse>();
            foreach (UserCamera userCamera in userCameras)
            {
                detections.AddRange(await detectionCRUDService.ReadDetection(fromDate, toDate , userCamera.CameraId));
            }
            return detections;
        }

        public async Task InsertDetection(InsertDetection detection)
        {
            Response.IsSuccessful = true;

            if (detection.WeatherId == 0 || detection.CameraId == 0)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "You Must provide WeatherId CameraId ";
                return ;
            }

            Detection newDetection = new Detection()
            {
                DetectionId = 0,
                WeatherId = detection.WeatherId,
                CameraId = detection.CameraId,
                Date = DateTime.UtcNow,
                ImagePath = detection.ImagePath
            };
            if(! await detectionCRUDService.InsertDetection(newDetection))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Cannot Insert Detecion ";
                return;
            }
        }
    }
}
