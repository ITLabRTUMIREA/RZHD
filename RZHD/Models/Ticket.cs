using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZHD.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArriveTime { get; set; }

        public List<Station> Stations { get; set; }
    }
}
