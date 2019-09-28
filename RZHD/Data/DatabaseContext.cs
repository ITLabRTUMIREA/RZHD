using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RZHD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZHD.Data
{
    public class DatabaseContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Station> Stations { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<StationRestaurant> StationRestaurants { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<StationTrain> StationTrains { get; set; }

        public DatabaseContext(DbContextOptions options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ConfigureStation(builder);
            ConfigureRestaurant(builder);
            ConfigureStationRestaurant(builder);
            ConfigureTicket(builder);
            ConfigureTrain(builder);
            ConfigureStationTrain(builder);
        }

        private void ConfigureStationTrain(ModelBuilder builder)
        {
            builder.Entity<StationTrain>()
                .HasKey(st => new { st.StationId, st.TrainId });

            builder.Entity<StationTrain>()
                .HasOne(st => st.Train)
                .WithMany(tr => tr.Stations)
                .HasForeignKey(st => st.TrainId);

            builder.Entity<StationTrain>()
                .HasOne(st => st.Station)
                .WithMany(st => st.Trains)
                .HasForeignKey(st => st.StationId);
        }

        private void ConfigureTrain(ModelBuilder builder)
        {
            builder.Entity<Train>()
                .HasKey(tr => tr.Id);
        }

        private void ConfigureTicket(ModelBuilder builder)
        {
            builder.Entity<Ticket>()
                .HasKey(tic => tic.Id);

            builder.Entity<Ticket>()
                .HasMany(tic => tic.Stations);

            builder.Entity<Ticket>()
                .HasIndex(tic => tic.Number)
                .IsUnique();
        }

        private void ConfigureStationRestaurant(ModelBuilder builder)
        {
            builder.Entity<StationRestaurant>()
                .HasKey(sr => new { sr.StationId, sr.RestaurantId });

            builder.Entity<StationRestaurant>()
                .HasOne(sr => sr.Station)
                .WithMany(sr => sr.DeliverRestaurants)
                .HasForeignKey(sr => sr.StationId);

            builder.Entity<StationRestaurant>()
                .HasOne(sr => sr.Restaurant)
                .WithMany(sr => sr.DeliverStations)
                .HasForeignKey(sr => sr.RestaurantId);
        }

        private void ConfigureRestaurant(ModelBuilder builder)
        {
            builder.Entity<Restaurant>()
                .HasKey(res => res.Id);

            builder.Entity<Restaurant>()
                .HasMany(res => res.DeliverStations);
        }

        private void ConfigureStation(ModelBuilder builder)
        {
            builder.Entity<Station>()
                .HasKey(st => st.Id);

            builder.Entity<Station>()
                .HasMany(st => st.DeliverRestaurants);
        }
    }
}
