using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZHD.Models.Responses.Stations
{
    public class StationTimeView
    {
        public StationView Station { get; set; }
        public TimeSpan Time { get; set; }
    }
}
