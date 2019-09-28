using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZHD.Models
{
    public class Train
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int WagonsNumber { get; set; }

        public List<StationTrain> Stations { get; set; }
    }
}
