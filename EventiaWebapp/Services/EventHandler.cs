using DataLayer.Data;
using EventiaWebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Services
{


    public class EventHandler
    {

        private readonly EventiaDbContext _context;

        public EventHandler(EventiaDbContext context)
        {

            _context = context;
            UserEventsList(1);

        }

        //TODO(✓)  - En metod som retunerar en lista på alla events.
        public List<Event> GetEvents()
        {
            var query = _context.Events
                .ToList();

            return query;

        }


        //TODO(✓)  - En metod som retunerar ett default deltagarobjekt (alltid samma i denna uppgift).
        public Attendee GetAttendee(int userId)
        {
            var query = _context.Attendees
                .FirstOrDefault(a => a.AttendeeId == userId);

            return query;
        }


        //TODO()  - En metod som retunerar ett givet deltagarobjekt med ett givet eventobjekt.




        //TODO(✓)  - En metod som retunerar en lista på alla events som ett givet deltagarobjekt deltar i. 
        public List<Attendee> UserEventsList(int userId)
        {

            userId = 1;

            var query = _context.Attendees
                .Where(a => a.AttendeeId == userId)
                .Include(a => a.Events);

            var eventList = query.ToList();


            return eventList;
        }



    }

}
