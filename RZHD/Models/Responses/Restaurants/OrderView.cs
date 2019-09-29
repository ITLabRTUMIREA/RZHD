using RZHD.Models.Responses.Stations;
using System.Collections.Generic;

namespace RZHD.Models.Responses.Restaurants
{
    public class OrderView
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public int TotalPrice { get; set; }

        public List<ProductView> Products { get; set; }
        public List<StationView> Stations { get; set; }
        public List<RestaurantView> Restaurants { get; set; }
    }
}
