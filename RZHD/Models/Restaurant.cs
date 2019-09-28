using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZHD.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<StationRestaurant> DeliverStations { get; set; }
    }
}
