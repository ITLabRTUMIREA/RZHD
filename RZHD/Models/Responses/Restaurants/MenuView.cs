using System.Collections.Generic;

namespace RZHD.Models.Responses.Restaurants
{
    public class MenuView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductView> Products { get; set; }
    }
}
