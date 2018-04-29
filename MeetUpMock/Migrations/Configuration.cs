namespace MeetUpMock.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using MeetUpMock.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MeetUpMock.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MeetUpMock.Data.DataContext db)
        {

            var cityList = new List<City>
            {
                new City {Name = "Ganymede"},
                new City {Name = "Europa"},
                new City {Name = "Io"},
                new City {Name = "Callisto" }
            };

            cityList.ForEach(city =>
            {
                db.Cities.AddOrUpdate(a => a.Name, city);
            });

            var visitorList = new List<Attendee>
            {
                new Attendee { Email = "Jet@test.com" },
                new Attendee { Email = "Spike@test.com" },
                new Attendee { Email = "Faye@test.com" }
            };

            var eventList = new List<Event>
            {
                new Event {Title = "How to Survive Without Water", Tagline="Moon Juice!", Date = new DateTime(2018, 7,7), CityID = 1, AgeLimit=0 },
                new Event {Title = "How to Eat Moon Rocks", Tagline="Ave Your Teeth!", Date = new DateTime(2018, 10,7), CityID = 2, AgeLimit=12 },
                new Event {Title = "Building On Your Moon", Tagline="Building Code 101", Date = new DateTime(2018, 11, 11), CityID = 3, AgeLimit=21 },
                new Event {Title = "Moon Law", Tagline="Avoid Jailtime, Know the Law!", Date = new DateTime(2018, 12,12), CityID = 4, AgeLimit=16 },
                };

            eventList.ForEach(item =>
            {
                foreach (var visitor in visitorList)
                {
                    item.Attendees.Add(visitor);
                }
                db.Events.AddOrUpdate(a => a.Title, item);
            });

            db.SaveChanges();

        }
    }
}
