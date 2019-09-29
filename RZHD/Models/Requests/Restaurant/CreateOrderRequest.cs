using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZHD.Models.Requests.Restaurant
{
    public class CreateOrderRequest
    {
        public int TotalPrice { get; set; }

        public List<int> ProductsId { get; set; }

        public List<int> RestaurantsId { get; set; }

        public List<int> StationsId { get; set; }
    }
}
