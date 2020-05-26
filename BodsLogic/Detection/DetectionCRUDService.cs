using BodsData;
using BodsEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BodsLogic
{
    public class DetectionCRUDService
    {
        public DetectionCRUDService()
        {
            this.detectionData = new DetectionData();
        }

        public DetectionData detectionData { get; set; }

        public async Task<List<Detection>> GetDetection(int detectionId)
        {
            return await detectionData.GetDetection(detectionId);

        }

        public async Task<bool> InsertDetection(Detection detection)
        {
            return await detectionData.InsertDetection(detection);
        }
        public async Task<List<Detection>> GetDetectionByCameraId(int cameraId)
        {
            return await detectionData.GetDetectionByCameraId(cameraId);
        }
        public async Task<List<DetectionResponse>> ReadDetection(DateTime fromDate, DateTime toDate , int cameraId)
        {
            return await detectionData.ReadDetection(fromDate , toDate , cameraId);
        }
    }
}
