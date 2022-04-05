using Microsoft.AspNetCore.Identity;

namespace DataLayer.Model
{
    public class EventiaUser : IdentityUser
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }



        public ICollection<Event>? HostedEvent { get; set; }


        public ICollection<Event>? JoinedEvent { get; set; }
    }
}
