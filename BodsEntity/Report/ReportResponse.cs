using System;
using System.Collections.Generic;
using System.Text;

namespace BodsEntity
{
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
