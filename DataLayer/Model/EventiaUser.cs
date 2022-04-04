using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
    public class EventiaUser : IdentityUser
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }


        [InverseProperty("organizer")]
        public ICollection<Event>? HostedEvent { get; set; }


        [InverseProperty("attendee")]
        [ForeignKey("Event")]
        public ICollection<Event>? JoinedEvent { get; set; }
    }
}
