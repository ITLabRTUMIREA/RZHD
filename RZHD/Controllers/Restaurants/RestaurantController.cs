using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RZHD.Data;
using RZHD.Models.Responses.Restaurants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RZHD.Controllers.Restaurants
{
    [Route("api/restaurant")]
    public class RestaurantController : MainController
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public RestaurantController(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantView>>> Get()
        {
            return Ok(await context.Restaurants
                .ProjectTo<RestaurantView>(mapper.ConfigurationProvider)
                .ToListAsync());
        }
    }
}
