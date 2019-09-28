using RZHD.Models.Responses.Stations;
using System.Collections.Generic;

namespace RZHD.Models.Responses.Restaurants
{
    public class RestaurantView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public List<StationTimeView> StationTime { get; set; }
    }
}
