using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZHD.Models
{
    public class StationTrain
    {
        public DateTime ArriveTime { get; set; }

        public int TrainId { get; set; }
        public Train Train { get; set; }

        public int StationId { get; set; }
        public Station  Station { get; set; }
    }
}
