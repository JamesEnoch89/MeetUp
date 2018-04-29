using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetUpMock.Models
{
    public class City
    {
        public int ID  { get; set; }
        public string Name { get; set; }

        public ICollection<Event> Events { get; set; } = new HashSet<Event>();
    }
}