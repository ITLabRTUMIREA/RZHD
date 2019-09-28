using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RZHD.Data;
using RZHD.Models;
using RZHD.Models.Responses;
using RZHD.Models.Responses.Restaurants;
using RZHD.Models.Responses.Stations;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("{ticket:string}")]
        public async Task<ActionResult<Response<IEnumerable<RestaurantView>>>> Get(string ticket)
        {
            var response = new Response<List<RestaurantView>>
            {
                Status = false,
                Error = "Something went critical wrong!!!",
                Content = new List<RestaurantView>()
            };

            try
            {
                // ticket has all stations
                var tick = await context.Tickets.Where(t => t.Number == ticket)
                    .Include(t => t.Stations)
                    .SingleAsync();

                var time = new DateTime(2019, 9, 28, 21, 37, 0);

                List<RestaurantView> result = new List<RestaurantView>();

                foreach (var station in tick.Stations)
                {
                    // get all restaurants
                    var st = await context.Stations.Where(s => s.Id == station.StationId)
                        .Include(s => s.DeliverRestaurants)
                        .Include(s => s.Trains)
                        .SingleAsync();

                    if (st.Trains.Count == 0)
                        continue;


                    // get one train
                    StationTrain train = null;
                    foreach (var trai in st.Trains)
                    {
                        var temp = context.Trains.Where(tra => tra.Id == trai.TrainId).SingleAsync().Result;
                        if (temp.Number == ticket)
                        {
                            trai.Train = temp;
                            train = trai;
                            break;
                        }
                    }

                    if (train == null)
                        continue;

                    foreach (var restaurant in st.DeliverRestaurants)
                    {
                        // too late
                        if (train.ArriveTime < time)
                            continue;

                        // if less - no time
                        if (train.ArriveTime - time < restaurant.DeliverTime)
                            continue;

                        result.Add(new RestaurantView
                        {
                            Id = restaurant.RestaurantId,
                            Name = (await context.Restaurants.Where(res => res.Id == restaurant.RestaurantId).SingleAsync()).Name,
                            ImageUrl = (await context.Restaurants.Where(res => res.Id == restaurant.RestaurantId).SingleAsync()).ImageUrl,
                            StationTime = new List<StationTimeView>()
                        });
                        TimeSpan temp = train.ArriveTime - time;
                        string timeStr = temp.Days + " " + temp.Hours + " " + temp.Minutes; 
                        result.Last().StationTime.Add(new StationTimeView
                        {
                            Station = mapper.Map<StationView>(st),
                            Time = timeStr
                        });
                    }
                }

                result.ForEach(r => r.StationTime.OrderBy(stt => stt.Time));
                response.Content = result;
                response.Error = "";
                response.Status = true;
                return Ok(response);
            }
            catch (ArgumentNullException ane)
            {
                response.Error = ane.Message;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
                return Ok(response);
            }
        }
    }
}
