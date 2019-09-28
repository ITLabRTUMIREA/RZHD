using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZHD.Models
{
    public class StationRestaurant
    {
        public TimeSpan DeliverTime { get; set; }

        public int StationId { get; set; }
        public Station Station { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
