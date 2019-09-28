using System;

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
