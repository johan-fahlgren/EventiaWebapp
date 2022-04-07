using DataLayer.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Data
{
    public class EventiaDbContext : IdentityDbContext<EventiaUser, IdentityRole, string>
    {
        public DbSet<Event?> Events { get; set; }
        public DbSet<RoleApplication> RoleApplications { get; set; }

        public EventiaDbContext(DbContextOptions options) : base(options) { }

    }
}
