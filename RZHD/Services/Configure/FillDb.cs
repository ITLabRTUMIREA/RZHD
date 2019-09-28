using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RZHD.Data;
using RZHD.Models;
using RZHD.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Configure.Models.Configure.Interfaces;

namespace RZHD.Services.Configure
{
    public class FillDb : IConfigureWork
    {
        private readonly DatabaseContext context;
        private readonly UserManager<User> userManager;
        private readonly FillDbOptions options;

        public FillDb(DatabaseContext context, IOptions<FillDbOptions> options,
            UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.options = options.Value;
        }
        public async Task Configure()
        {
            await AddDefaultUser();
            await AddStations();
            await AddRestaurants();
            await AddTickets();
            await AddTrains();


            await AddLinks();
        }

        private async Task AddTrains()
        {
            foreach (var train in context.Trains)
                context.Trains.Remove(train);

            context.Trains.Add(new Train
            {
                Number = "num123",
                WagonsNumber = 13,
                ArriveTIme = new DateTime(2019, 10, 2, 0, 0, 0),
                DepartureTime = new DateTime(2019, 9, 28, 20, 50, 0)
            });

            await context.SaveChangesAsync();
        }

        private async Task AddLinks()
        {
            var sts = await context.Stations.ToListAsync();
            // tickets
            foreach (var ticket in context.Tickets)
            {
                ticket.Stations = new List<StationTicket>();
                ticket.Stations.Add(new StationTicket
                {
                    StationId = sts[0].Id,
                    Station = sts[0],
                    TicketId = ticket.Id,
                    Ticket = ticket
                });
                ticket.Stations.Add(new StationTicket
                {
                    StationId = sts[1].Id,
                    Station = sts[1],
                    TicketId = ticket.Id,
                    Ticket = ticket
                });
            }

            await context.SaveChangesAsync();

            // restaurant
            foreach (var res in context.Restaurants)
            {
                res.DeliverStations = new List<StationRestaurant>();
                res.DeliverStations.Add(new StationRestaurant
                {
                    DeliverTime = TimeSpan.FromMinutes(10),
                    RestaurantId = res.Id,
                    Restaurant = res,
                    StationId = sts[0].Id,
                    Station = sts[0]
                });
                res.DeliverStations.Add(new StationRestaurant
                {
                    DeliverTime = TimeSpan.FromMinutes(20),
                    RestaurantId = res.Id,
                    Restaurant = res,
                    StationId = sts[1].Id,
                    Station = sts[1]
                });
            }

            await context.SaveChangesAsync();

            // trains
            foreach (var train in context.Trains)
            {
                train.Stations = new List<StationTrain>();
                train.Stations.Add(new StationTrain
                {
                    ArriveTime = train.DepartureTime + TimeSpan.FromMinutes(new Random().Next(60, 78)),
                    TrainId = train.Id,
                    Train = train,
                    StationId = sts[0].Id,
                    Station = sts[0]
                });
                train.Stations.Add(new StationTrain
                {
                    ArriveTime = train.DepartureTime + TimeSpan.FromMinutes(new Random().Next(42, 60)),
                    TrainId = train.Id,
                    Train = train,
                    StationId = sts[1].Id,
                    Station = sts[1]
                });
                await Task.Delay(5);
            }

            await context.SaveChangesAsync();
        }

        private async Task AddTickets()
        {
            foreach (var t in context.Tickets)
                context.Remove(t);

            await context.SaveChangesAsync();

            context.Tickets.Add(new Ticket
            {
                Number = "num123",
                DepartureTime = new DateTime(2019, 9, 29, 9, 30, 0),
                ArriveTime = new DateTime(2019, 9, 28, 20, 50, 0),
                WagonNumber = 9
            });

            await context.SaveChangesAsync();
        }

        private async Task AddRestaurants()
        {
            foreach (var res in context.Restaurants)
                context.Restaurants.Remove(res);

            await context.SaveChangesAsync();

            context.Restaurants.Add(new Restaurant
            {
                Name = "Русский повар"
            });

            context.Restaurants.Add(new Restaurant
            {
                Name = "Якитория"
            });

            context.Restaurants.Add(new Restaurant
            {
                Name = "Бургеркинг"
            });

            context.Restaurants.Add(new Restaurant
            {
                Name = "Казахстан"
            });

            context.Restaurants.Add(new Restaurant
            {
                Name = "МакДоналдс"
            });

            context.Restaurants.Add(new Restaurant
            {
                Name = "КФС"
            });

            await context.SaveChangesAsync();
        }

        private async Task AddStations()
        {
            foreach (var st in context.Stations)
                context.Stations.Remove(st);

            await context.SaveChangesAsync();

            context.Stations.Add(new Station
            {
                Name = "Нижний Новгород"
            });

            context.Stations.Add(new Station
            {
                Name = "Казанксий вокзал"
            });

            await context.SaveChangesAsync();
        }

        private async Task AddDefaultUser()
        {
            if (!await userManager.Users.AnyAsync(u => u.Email == options.Email))
            {
                var r = await userManager.CreateAsync(new User
                {
                    Firstname = options.Firstname,
                    Secondname = options.Secondname,
                    Middlename = options.Middlename,
                    Email = options.Email,
                    UserName = options.Email,
                    Age = options.Age,
                    BonusQuantity = options.BonusQuantity
                }, options.Password);
                Console.WriteLine("Create default user ------- " + r.Succeeded);
            }
        }
    }
}
