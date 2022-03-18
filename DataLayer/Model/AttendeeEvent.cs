using System.ComponentModel.DataAnnotations;

namespace EventiaWebapp.Models
{
    public class AttendeeEvent
    {

        public int AttendeeId { get; set; }
        [Required]
        public Attendee Attendee { get; set; }


        public int EventId { get; set; }
        public Event Event { get; set; }


    }
}