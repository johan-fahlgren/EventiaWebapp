using System.ComponentModel.DataAnnotations;

namespace EventiaWebapp.Models
{
    public class Attendee
    {

        public int AttendeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone_Number { get; set; }

        public ICollection<AttendeeEvent> AttendeeEvents { get; set; }

    }
}
