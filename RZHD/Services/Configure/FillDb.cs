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
                Number = "069ИА",
                WagonsNumber = 13
            });

            context.Trains.Add(new Train
            {
                Number = "070ИА",
                WagonsNumber = 12
            });

            context.Trains.Add(new Train
            {
                Number = "065И",
                WagonsNumber = 9
            });

            context.Trains.Add(new Train
            {
                Number = "066И",
                WagonsNumber = 9
            });

            context.Trains.Add(new Train
            {
                Number = "099МК",
                WagonsNumber = 13
            });

            context.Trains.Add(new Train
            {
                Number = "100МК",
                WagonsNumber = 12
            });

            await context.SaveChangesAsync();
        }

        private async Task AddLinks()
        {
            // tickets
            foreach (var ticket in context.Tickets)
            {
                var sts = await context.Stations.ToListAsync();
                ticket.Stations = sts.GetRange(new Random().Next(5), 2);
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
                    DeliverTime = TimeSpan.FromMinutes(40),
                    RestaurantId = res.Id,
                    Restaurant = res,
                    StationId = sts[0].Id,
                    Station = sts[0]
                });
                res.DeliverStations.Add(new StationRestaurant
                {
                    DeliverTime = TimeSpan.FromMinutes(35),
                    RestaurantId = res.Id,
                    Restaurant = res,
                    StationId = sts[1].Id,
                    Station = sts[1]
                });
                res.DeliverStations.Add(new StationRestaurant
                {
                    DeliverTime = TimeSpan.FromMinutes(15),
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

            }
        }

        private async Task AddTickets()
        {
            foreach (var t in context.Tickets)
                context.Remove(t);

            await context.SaveChangesAsync();

            context.Tickets.Add(new Ticket
            {
                Number = "num123",
                DepartureTime = new DateTime(2019, 10, 3, 23, 54, 0),
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
