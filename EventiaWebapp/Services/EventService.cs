using DataLayer.Data;
using DataLayer.Model;
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

        public async Task<List<Event?>> GetEvents()
        {
            var eventList = await _context.Events
                .Include(e => e.organizer)
                .ToListAsync();

            return eventList;
        }

        public async Task<Event?> GetThisEvent(int eventId)
        {
            var thisEvent = await _context.Events
                .Include(e => e.organizer)
                .FirstOrDefaultAsync(e => e.EventId == eventId);

            return thisEvent;
        }



        //TODO(✓)  - A method that returns a default Attendee object (always the same object for exercise).
        public async Task<EventiaUser?> GetUser(string userId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(a => a.Id == userId);

            return user;
        }


        //TODO(✓)  - A method that adds a event object to a attendee object.
        public async Task<bool> AddEventToAttendee(string userId, int eventId)
        {
            var user = await _context.Users
                .Include(u => u.JoinedEvent)
                .FirstOrDefaultAsync(u => u.Id == userId);

            var thisEvent = await _context.Events
                .FirstOrDefaultAsync(e => e.EventId == eventId);

            if (user is null || thisEvent is null) return false;

            user.JoinedEvent.Add(thisEvent);
            await _context.SaveChangesAsync();
            return true;

        }


        //TODO(✓)  - A method that returns a list of all events for one Attendee object. 
        public async Task<List<Event>> UserEventsList(string userId)
        {
            var user = await _context.Users
                .Include(u => u.JoinedEvent)
                .FirstOrDefaultAsync(u => u.Id == userId);

            var eventList = user.JoinedEvent.ToList();

            eventList.Sort((date1, date2) =>
               DateTime.Compare(date1.Date, date2.Date));

            return eventList;
        }

    }

}
