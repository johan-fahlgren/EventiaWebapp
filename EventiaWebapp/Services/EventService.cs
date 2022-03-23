using DataLayer.Data;
using EventiaWebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Services
{
    public class EventService
    {
        private readonly EventiaDbContext _context;

        public EventService(EventiaDbContext context)
        {
            _context = context;
        }

        //TODO(✓)  - A method that returns a list of all events.
        public List<Event?> GetEvents()
        {
            var eventList = _context.Events
                .Include(e => e.Organizer)
                .ToList();

            return eventList;

        }


        //TODO(✓)  - A method that returns a default Attendee object (always the same object for exercise).
        public Attendee GetAttendee(int userId)
        {

            var attendee = _context.Attendees
               .FirstOrDefault(a => a.AttendeeId == userId);

            return (attendee ?? null) ?? throw new InvalidOperationException();

        }


        //TODO(✓)  - A method that adds a event object to a attendee object.
        public void AddEventToAttendee(int userId, int eventId)
        {
            var attendee = _context.Attendees
                .Include(a => a.Events)
                .FirstOrDefault(a => a.AttendeeId == userId);

            var thisEvent = _context.Events
                .FirstOrDefault(e => e.EventId == eventId);


            attendee.Events.Add(thisEvent);
            _context.SaveChanges();


        }


        //TODO(✓)  - A method that returns a list of all events for one Attendee object. 
        public List<Event> UserEventsList(int userId)
        {
            userId = 1;  //default userId

            var attendee = _context.Attendees
                .Include(a => a.Events)
                .FirstOrDefault(a => a.AttendeeId == userId);

            var eventList = attendee.Events.ToList();

            eventList.Sort((date1, date2) =>
               DateTime.Compare(date1.Date, date2.Date));

            return eventList;
        }



    }

}
