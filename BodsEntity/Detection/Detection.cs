using System;
using System.Collections.Generic;
using System.Text;

namespace BodsEntity
{
    // define detection object as it stored at DB
    public class Detection
    {
        public int DetectionId { get; set; }
        public int CameraId { get; set; }
        public string ImagePath { get; set; }
        public int WeatherId { get; set; }
        public DateTime Date { get; set; }
    }
}
