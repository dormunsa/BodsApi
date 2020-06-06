using System;
using System.Collections.Generic;
using System.Text;

namespace BodsEntity
{
    public class BasicChartResponse
    {
        public BasicChartResponse(string name, List<int> data)
        {
            Name = name;
            Data = data;
        }

        public string Name { get; set; }
        public List<int> Data { get; set; }
    }
}
