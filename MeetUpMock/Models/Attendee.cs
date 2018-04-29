using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeetUpMock.Models
{
    public class Attendee
    {
        public int ID { get; set; }
        [Required]
        public string Email { get; set; }

        // set up contract between attendee and event
        public ICollection<Event> Events { get; set; } = new HashSet<Event>();
    }
}