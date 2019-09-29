using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZHD.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public int TotalPrice { get; set; }

        public List<Product> Products { get; set; }
        public List<Station> Stations { get; set; }
        public List<Restaurant> Restaurants { get; set; }
    }

    public enum Status
    {
        Payed,
        ConfirmRequest,
        Cook,
        InTravel,
        WaitingForClient,
        Delivered
    }
}
