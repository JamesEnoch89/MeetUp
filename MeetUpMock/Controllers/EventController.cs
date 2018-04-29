using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MeetUpMock.Models;
using MeetUpMock.ViewModels;
using System.Data.Entity;
using MeetUpMock.Data;

namespace MeetUpMock.Controllers
{
    public class EventController : ApiController
        // get all events with their attendees
    {
        public IEnumerable <Event> GetAllEvents()
        {
            using (var db = new DataContext())
            {
                return db.Events.Include(i => i.Attendees).ToList();
            }
        }
        // get an event, include the attendees, city, where the event id = param id
        // if those values are not found in the db, return not found, otherwise return the request
        [HttpGet]
        public IHttpActionResult GetAnEvent(int id)
        {
            using (var db = new DataContext())
            {
                var query = db.Events
                    .Include(i => i.Attendees)
                    .Include(i => i.City)
                    .SingleOrDefault(s => s.ID == id);
                if (query == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(query);
                }

            }
        }
    }
}
