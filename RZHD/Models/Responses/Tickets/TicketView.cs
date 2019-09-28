using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZHD.Models.Responses.Tickets
{
    public class TicketView
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArriveTime { get; set; }
    }
}
