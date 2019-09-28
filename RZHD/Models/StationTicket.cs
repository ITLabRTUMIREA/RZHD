using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZHD.Models
{
    public class StationTicket
    {
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public int StationId { get; set; }
        public Station Station { get; set; }
    }
}
