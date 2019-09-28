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
                ArriveTIme = new DateTime(2020, 1, 1, 0,0,0),
                DepartureTime = new DateTime(2019,1,1,0,0,0)
            });

            context.Trains.Add(new Train
            {
                Number = "kjl120",
                WagonsNumber = 12,
                ArriveTIme = new DateTime(2020, 1, 1, 0, 0, 0),
                DepartureTime = new DateTime(2019, 1, 1, 0, 0, 0)
            });

            context.Trains.Add(new Train
            {
                Number = "dfr780",
                WagonsNumber = 9,
                ArriveTIme = new DateTime(2020, 1, 1, 0, 0, 0),
                DepartureTime = new DateTime(2019, 1, 1, 0, 0, 0)
            });

            context.Trains.Add(new Train
            {
                Number = "gtr945",
                WagonsNumber = 9,
                ArriveTIme = new DateTime(2020, 1, 1, 0, 0, 0),
                DepartureTime = new DateTime(2019, 1, 1, 0, 0, 0)
            });

            context.Trains.Add(new Train
            {
                Number = "dfdg80",
                WagonsNumber = 13,
                ArriveTIme = new DateTime(2020, 1, 1, 0, 0, 0),
                DepartureTime = new DateTime(2019, 1, 1, 0, 0, 0)
            });

            context.Trains.Add(new Train
            {
                Number = "gteq945",
                WagonsNumber = 12,
                ArriveTIme = new DateTime(2020, 1, 1, 0, 0, 0),
                DepartureTime = new DateTime(2019, 1, 1, 0, 0, 0)
            });

            await context.SaveChangesAsync();
        }

        private async Task AddLinks()
        {
            // tickets
            foreach (var ticket in context.Tickets)
            {
                var sts = await context.Stations.ToListAsync();
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
                ticket.Stations.Add(new StationTicket
                {
                    StationId = sts[2].Id,
                    Station = sts[2],
                    TicketId = ticket.Id,
                    Ticket = ticket
                });
                ticket.Stations.Add(new StationTicket
                {
                    StationId = sts[3].Id,
                    Station = sts[3],
                    TicketId = ticket.Id,
                    Ticket = ticket
                });
                ticket.Stations.Add(new StationTicket
                {
                    StationId = sts[4].Id,
                    Station = sts[4],
                    TicketId = ticket.Id,
                    Ticket = ticket
                });
                ticket.Stations.Add(new StationTicket
                {
                    StationId = sts[5].Id,
                    Station = sts[5],
                    TicketId = ticket.Id,
                    Ticket = ticket
                });
            }

            await context.SaveChangesAsync();

            // restaurant
            foreach (var res in context.Restaurants)
            {
                var s = await context.Stations.ToListAsync();
                var sts = s.GetRange(new Random().Next(4), 3);
                res.DeliverStations = new List<StationRestaurant>();
                res.DeliverStations.Add(new StationRestaurant
                {
                    DeliverTime = TimeSpan.FromMinutes(65),
                    RestaurantId = res.Id,
                    Restaurant = res,
                    StationId = sts[0].Id,
                    Station = sts[0]
                });
                res.DeliverStations.Add(new StationRestaurant
                {
                    DeliverTime = TimeSpan.FromMinutes(90),
                    RestaurantId = res.Id,
                    Restaurant = res,
                    StationId = sts[1].Id,
                    Station = sts[1]
                });
                res.DeliverStations.Add(new StationRestaurant
                {
                    DeliverTime = TimeSpan.FromMinutes(40),
                    RestaurantId = res.Id,
                    Restaurant = res,
                    StationId = sts[2].Id,
                    Station = sts[2]
                });
            }

            await context.SaveChangesAsync();

            // trains
            foreach (var train in context.Trains)
            {
                var sts = await context.Stations.ToListAsync();
                train.Stations = new List<StationTrain>();
                train.Stations.Add(new StationTrain
                {
                    ArriveTime = train.DepartureTime + TimeSpan.FromMinutes(30),
                    TrainId = train.Id,
                    Train = train,
                    StationId = sts[0].Id,
                    Station = sts[0]
                });
                train.Stations.Add(new StationTrain
                {
                    ArriveTime = train.DepartureTime + TimeSpan.FromMinutes(70),
                    TrainId = train.Id,
                    Train = train,
                    StationId = sts[1].Id,
                    Station = sts[1]
                });
                train.Stations.Add(new StationTrain
                {
                    ArriveTime = train.DepartureTime + TimeSpan.FromMinutes(100),
                    TrainId = train.Id,
                    Train = train,
                    StationId = sts[2].Id,
                    Station = sts[2]
                });
                train.Stations.Add(new StationTrain
                {
                    ArriveTime = train.DepartureTime + TimeSpan.FromMinutes(100),
                    TrainId = train.Id,
                    Train = train,
                    StationId = sts[3].Id,
                    Station = sts[3]
                });
                train.Stations.Add(new StationTrain
                {
                    ArriveTime = train.DepartureTime + TimeSpan.FromMinutes(100),
                    TrainId = train.Id,
                    Train = train,
                    StationId = sts[4].Id,
                    Station = sts[4]
                });
                train.Stations.Add(new StationTrain
                {
                    ArriveTime = train.DepartureTime + TimeSpan.FromMinutes(100),
                    TrainId = train.Id,
                    Train = train,
                    StationId = sts[5].Id,
                    Station = sts[5]
                });
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
                DepartureTime = new DateTime(2019, 1, 1, 0, 30, 0),
                ArriveTime = new DateTime(2019, 10, 5, 10, 30, 0),
                WagonNumber = 9
            });

            context.Tickets.Add(new Ticket
            {
                Number = "kjl120",
                DepartureTime = new DateTime(2019, 12, 18, 10, 35, 0),
                ArriveTime = new DateTime(2019, 12, 20, 12, 0, 0),
                WagonNumber = 3                
            });

            context.Tickets.Add(new Ticket
            {
                Number = "dfr780",
                DepartureTime = new DateTime(2020, 1, 18, 0, 0, 0),
                ArriveTime = new DateTime(2020, 1, 29, 12, 30, 5),
                WagonNumber = 1
            });

            context.Tickets.Add(new Ticket
            {
                Number = "gtr945",
                DepartureTime = new DateTime(2019, 3, 5, 9, 14, 0),
                ArriveTime = new DateTime(2019, 3, 10, 10, 54, 0),
                WagonNumber = 5
            });

            context.Tickets.Add(new Ticket
            {
                Number = "dfdg80",
                DepartureTime = new DateTime(2020, 1, 18, 0, 0, 0),
                ArriveTime = new DateTime(2020, 1, 29, 12, 30, 5),
                WagonNumber = 10
            });

            context.Tickets.Add(new Ticket
            {
                Number = "gteq945",
                DepartureTime = new DateTime(2019, 3, 5, 9, 14, 0),
                ArriveTime = new DateTime(2019, 3, 10, 10, 54, 0),
                WagonNumber = 7
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

            context.Stations.Add(new Station
            {
                Name = "Адлер"
            });

            context.Stations.Add(new Station
            {
                Name = "Ярославский вокзал"
            });

            context.Stations.Add(new Station
            {
                Name = "Киров"
            });

            context.Stations.Add(new Station
            {
                Name = "Пермь"
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
