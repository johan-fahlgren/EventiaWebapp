using DataLayer.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Data
{
    public class EventiaDbContext : IdentityDbContext<EventiaUser, IdentityRole, string>
    {
        //public DbSet<Attendee>? Attendees { get; set; }
        public DbSet<Event?>? Events { get; set; }
        //public DbSet<Organizer>? Organizers { get; set; }


        public EventiaDbContext(DbContextOptions options) : base(options) { }

        /*
        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasOne(e => e.attendee)
                .WithMany(e => Events)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.organizer)
                .WithMany(o => Events)
                .OnDelete(DeleteBehavior.SetNull);
        }
        */



    }
}
