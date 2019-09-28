using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZHD.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<StationRestaurant> DeliverRestaurants { get; set; }

        public List<StationTrain> Trains { get; set; }

        public List<StationTicket> Tickets { get; set; }
    }
}
