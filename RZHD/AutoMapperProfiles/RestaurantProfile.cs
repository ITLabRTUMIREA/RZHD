using AutoMapper;
using RZHD.Models;
using RZHD.Models.Responses.Restaurants;

namespace RZHD.AutoMapperProfiles
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Restaurant, RestaurantView>();
        }
    }
}
