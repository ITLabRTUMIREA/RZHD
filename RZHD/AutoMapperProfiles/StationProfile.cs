using AutoMapper;
using RZHD.Models;
using RZHD.Models.Responses.Stations;

namespace RZHD.AutoMapperProfiles
{
    public class StationProfile : Profile
    {
        public StationProfile()
        {
            CreateMap<Station, StationView>();
        }
    }
}
