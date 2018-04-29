using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetUpMock.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Zip { get; set; } 
        public int? AgeLimit { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }

        public int? CityID { get; set; }
        public City City { get; set; }

        public ICollection<Attendee> Attendees { get; set; } = new HashSet<Attendee>();
    }
}