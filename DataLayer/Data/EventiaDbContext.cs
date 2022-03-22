using EventiaWebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Data
{
    public class EventiaDbContext : DbContext
    {
        public DbSet<Attendee>? Attendees { get; set; }
        public DbSet<Event?>? Events { get; set; }
        public DbSet<Organizer>? Organizers { get; set; }


        public EventiaDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }



    }
}
