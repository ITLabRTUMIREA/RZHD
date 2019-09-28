using AutoMapper;
using RZHD.Models;
using RZHD.Models.Requests.Auth;

namespace RZHD.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterRequest, User>();
        }
    }
}
