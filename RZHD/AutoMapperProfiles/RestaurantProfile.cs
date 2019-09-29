using AutoMapper;
using RZHD.Models;
using RZHD.Models.Requests.Restaurant;
using RZHD.Models.Responses.Restaurants;

namespace RZHD.AutoMapperProfiles
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Restaurant, RestaurantView>();

            // menu
            CreateMap<Category, MenuView>();
            CreateMap<Product, ProductView>();

            // order
            CreateMap<Order, OrderView>();
            CreateMap<CreateOrderRequest, Order>();
        }
    }
}
