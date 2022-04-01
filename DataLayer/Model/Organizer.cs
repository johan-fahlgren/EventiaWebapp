using System.ComponentModel.DataAnnotations;

namespace DataLayer.Model
{
    public class Organizer
    {
        public int OrganizerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone_Number { get; set; }

        public ICollection<Event> Event { get; set; }


    }
}
