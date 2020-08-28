using System;
using System.Collections.Generic;
using System.Text;

namespace BodsEntity
{
    // define object for get detection response 
    public class DetectionResponse
    {
        public int CameraId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        public string WeatherLocationName { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double WindSpeed { get; set; }
        public string Description { get; set; }
        public string CameraLocationName { get; set; }
    }
}
