﻿using BodsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
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
            cameraCRUDService = new CameraCRUDService();
        }

        public DetectionCRUDService detectionCRUDService { get; set; }
        public UserCRUDService userCRUDService { get; set; }
        public BaseResponse Response { get; set; }
        public UserCameraLogic userCameraLogic { get; set; }
        public CameraCRUDService cameraCRUDService { get; set; }

        public async Task<List<Detection>> GetDetection(int detectionId)
        {  
            // get all detections
            return await detectionCRUDService.GetDetection(detectionId);
        }

        public async Task<List<Detection>> GetByUserGuid(string guid)
        {
            // validate request values
            if (string.IsNullOrEmpty(guid))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Bad Request";
                return null;
            }
            // get user by guid 
            User user = await userCRUDService.GetByUserGuid(guid);
            if (user == null || user?.UserId == 0)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "user is not exist ";
                return null;
            }

            // get user cameras  by user id  
            List<UserCamera> userCameras = await userCameraLogic.GetByUserId(user.UserId);
            if (userCameras.Count == 0)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "no detections";
                return null;
            }

            // get detecions object by camera id in for each loop on user cameras
            List<Detection> detections = new List<Detection>();
            foreach (UserCamera userCamera in userCameras)
            {
                detections.AddRange(await detectionCRUDService.GetDetectionByCameraId(userCamera.CameraId));
            }
            return detections;
        }
        public async Task<List<DetectionResponse>> ReadDetection(DateTime fromDate, DateTime toDate , string guid)
        {
            // validate request values
            if (fromDate == null || toDate == null || string.IsNullOrEmpty(guid))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Bad Request";
                return null;
            }
            // get user by guid 
            User user = await userCRUDService.GetByUserGuid(guid);
            if (user == null || user?.UserId == 0)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "user is not exist ";
                return null;
            }
            // get user cameras  by user id  
            List<UserCamera> userCameras = await userCameraLogic.GetByUserId(user.UserId);
            if (userCameras.Count == 0)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "no detections";
                return null;
            }

            List<DetectionResponse> detections = new List<DetectionResponse>();
            // get detecions object by camera  id and dates  in for each loop on user cameras
            foreach (UserCamera userCamera in userCameras)
            {
                detections.AddRange(await detectionCRUDService.ReadDetection(fromDate, toDate , userCamera.CameraId));
            }
            return detections;
        }
       
        public async Task<ReportResponse> ReadDetectionChart(DateTime fromDate, DateTime toDate, string guid)
        {
            // validate request values
            if (fromDate == null || toDate == null || string.IsNullOrEmpty(guid))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Bad Request";
                return null;
            }
            // get user by guid 
            User user = await userCRUDService.GetByUserGuid(guid);
            if (user == null || user?.UserId == 0)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "user is not exist ";
                return null;
            }
            // get user cameras  by user id  
            List<UserCamera> userCameras = await userCameraLogic.GetByUserId(user.UserId);
            if (userCameras.Count == 0)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "no detections";
                return null;
            }
            ReportResponse detections = new ReportResponse();
            // build chart object in for each loop 
            foreach (UserCamera userCamera in userCameras)
            {
                //get camera by id 
                Camera camera = await cameraCRUDService.GetCameraById(userCamera.CameraId);
                //read detcions by camera id and dates
                List<DetectionResponse> detectionResponses = await detectionCRUDService.ReadDetection(fromDate, toDate, userCamera.CameraId);
                //get lists of dates and houers
                var dates = detectionResponses.GroupBy(d => d.Date.Date).Distinct();
                var houers = detectionResponses.GroupBy(d => d.Date.Hour).Distinct();

                //check if this one day report and return response by houres
                if (fromDate.Date == toDate.Date)
                {
                    List<int> count = new List<int>();
                    foreach (var item in houers)
                    {
                        count.Add(item.Count());
                        detections.Dates.Add( item.Key.ToString() + ":00");
                    }
                    if (count.Count > 0)
                    {
                        BasicChartResponse basicChart = new BasicChartResponse(camera.LocationName, count);
                        detections.ChartData.Add(basicChart);
                    }
                }

                //check if this many days report and return response by dayes
                else
                {
                    {
                        List<int> count = new List<int>();
                        foreach (var item in dates)
                        {
                            count.Add(item.Count());
                            detections.Dates.Add(item.Key.Date.Day.ToString() + '/' + item.Key.Date.Month.ToString() + '/' + item.Key.Date.Year.ToString());
                        }
                        if (count.Count > 0)
                        {
                            BasicChartResponse basicChart = new BasicChartResponse(camera.LocationName, count);
                            detections.ChartData.Add(basicChart);
                        }
                           
                    }
                    
                }

            }
            if (detections.ChartData.Count > 0)
            {
                detections.Dates = detections.Dates.Distinct().ToList();
                return detections;
            }
                
            return null;
        }
        

        public async Task InsertDetection(InsertDetection detection)
        {
            Response.IsSuccessful = true;
            // validate request values
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

            // insert detection
            if (! await detectionCRUDService.InsertDetection(newDetection))
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = "Cannot Insert Detecion ";
                return;
            }
        }
    }
}
