using System.ComponentModel.DataAnnotations;

namespace EventiaWebapp.Models
{
    public class Event
    {

        public int EventId { get; set; }
        [Required]
        public string Titel { get; set; }
        [Required]
        public Organizer Organizer { get; set; }
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

        public ICollection<Attendee> Attendees
        { get; set; }




    }
}
