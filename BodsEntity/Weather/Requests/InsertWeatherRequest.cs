using System;
using System.Collections.Generic;
using System.Text;

namespace BodsEntity
{
    // define object for insert weather operation
    public class InsertWeatherRequest
    {
        public string LocationName { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public float WindSpeed { get; set; }
        public string Description { get; set; }
    }
}
