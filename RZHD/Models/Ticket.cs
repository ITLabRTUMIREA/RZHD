using System;
using System.Collections.Generic;

namespace RZHD.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int WagonNumber { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArriveTime { get; set; }

        public List<StationTicket> Stations { get; set; }
    }
}
