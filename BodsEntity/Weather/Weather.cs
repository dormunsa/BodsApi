using System;
using System.Collections.Generic;
using System.Text;

namespace BodsEntity
{
    // define weather object as it stored at DB
    public class Weather
    {
        public int WeatherId { get; set; }
        public string LocationName { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime Date { get; set; }
        public double WindSpeed { get; set; }
        public string Description { get; set; }
    }
}
