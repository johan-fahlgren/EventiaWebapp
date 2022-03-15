using System.ComponentModel.DataAnnotations;

namespace EventiaWebapp.Models
{
    public class Attendee
    {

        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Phone_Number { get; set; }

        public ICollection<Event> Event { get; set; }

    }
}
