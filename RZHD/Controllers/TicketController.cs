using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RZHD.Data;
using RZHD.Models.Responses.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZHD.Controllers
{
    [Route("api/ticket")]
    public class TicketController : MainController
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public TicketController(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<TicketView>> GetOneTicket(string ticket)
        {
            if (!await context.Tickets.AnyAsync(t => t.Number == ticket))
            {
                return NotFound("Can't find ticket");
            }

            var ticketObj = mapper.Map<TicketView>(await context.Tickets
                .Where(t => t.Number == ticket)
                .SingleAsync());

            return Ok(ticketObj);
        }
    }
}
