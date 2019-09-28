
using AutoMapper;
using RZHD.Models;
using RZHD.Models.Responses.Tickets;

namespace RZHD.AutoMapperProfiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketView>();
        }
    }
}
