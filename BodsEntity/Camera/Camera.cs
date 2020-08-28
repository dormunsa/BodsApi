using System;
using System.Collections.Generic;
using System.Text;

namespace BodsEntity
{
    // define camera object as it stored at DB
    public class Camera
    {
        public int CameraId { get; set; }
        public string LocationName { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public bool IsWorking { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
