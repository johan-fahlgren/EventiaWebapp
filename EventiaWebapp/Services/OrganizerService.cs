using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Services
{
    public class OrganizerService
    {

        private readonly EventiaDbContext _dbContext;


        public OrganizerService(EventiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddEvent(Event newEvent)
        {
            await _dbContext.AddAsync(newEvent);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<List<Event>> GetOrganizerEvents(string userId)
        {
            var user = await _dbContext.Users
                .Include(u => u.HostedEvent)
                .FirstOrDefaultAsync(u => u.Id == userId);

            var eventList = user.HostedEvent.ToList();

            eventList.Sort((date1, date2) =>
                DateTime.Compare(date1.Date, date2.Date));

            return eventList;
        }

    }
}
