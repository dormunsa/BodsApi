using System;
using System.Collections.Generic;
using System.Text;

namespace BodsEntity
{
    // define object for update camera operation
    public class UpdateCameraRequest
    {
        public string LocationName { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int CameraId { get; set; }
        public bool IsWorking { get; set; }
    }
}
