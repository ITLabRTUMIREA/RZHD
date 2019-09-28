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
            //await AddStations();
            //await AddRestaurants();
            //await AddTickets();
        }

        private async Task AddTickets()
        {
            context.Tickets.Add(new Ticket
            {
                Number = "num123",
                DepartureTime = new DateTime(2019, 10, 3, 23, 54, 0),
                ArriveTime = new DateTime(2019, 10, 5, 10, 30, 0)
            });

            context.Tickets.Add(new Ticket
            {
                Number = "kjl120",
                DepartureTime = new DateTime(2019, 12, 18, 10, 35, 0),
                ArriveTime = new DateTime(2019, 12, 20, 12, 0, 0)
            });

            context.Tickets.Add(new Ticket
            {
                Number = "dfr780",
                DepartureTime = new DateTime(2020, 1, 18, 0, 0, 0),
                ArriveTime = new DateTime(2020, 1, 29, 12, 30, 5)
            });

            context.Tickets.Add(new Ticket
            {
                Number = "gtr945",
                DepartureTime = new DateTime(2019, 3, 5, 9, 14, 0),
                ArriveTime = new DateTime(2019, 3, 10, 10, 54, 0)
            });

            await context.SaveChangesAsync();
        }

        private async Task AddRestaurants()
        {
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

            // to save our restaurants
            await context.SaveChangesAsync();
        }

        private async Task AddStations()
        {
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
