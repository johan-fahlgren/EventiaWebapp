using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
    public class Event
    {

        public int EventId { get; set; }
        [Required]
        public string Titel { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Spots_Available { get; set; }

        public string EventImg { get; set; }



        [InverseProperty("HostedEvent")]
        [DisplayName("Organizer")]
        public EventiaUser organizer { get; set; }


        [InverseProperty("JoinedEvent")]
        public ICollection<EventiaUser>? attendee { get; set; }


    }
}
