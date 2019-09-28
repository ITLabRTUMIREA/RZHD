using RZHD.Models.Responses.Stations;
using System;

namespace RZHD.Models.Responses.Restaurants
{
    public class StationRestaurantView
    {
        public int StationId { get; set; }
        public StationView Station { get; set; }

        public int RestaurantId { get; set; }
        public RestaurantView Restaurant { get; set; }

        public TimeSpan Time { get; set; }
    }
}
