using System;
using System.Collections.Generic;
using System.Text;

namespace BodsEntity
{
    // define object for get basic table report of detection response 
    public class ReportResponse
    {
        public ReportResponse()
        {
            ChartData = new List<BasicChartResponse>();
            Dates = new List<string>();
        }

        public List<BasicChartResponse> ChartData { get; set; }
        public List<string> Dates { get; set; }
    }
}
