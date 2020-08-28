using System;
using System.Collections.Generic;
using System.Text;

namespace BodsEntity
{
    // define object for insert camera operation
    public class InsertCameraRequest
    {
        public string LocationName { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}
