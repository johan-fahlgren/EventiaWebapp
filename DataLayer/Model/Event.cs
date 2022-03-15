using System.ComponentModel.DataAnnotations;

namespace EventiaWebapp.Models
{
    public class Event
    {

        public Guid Id { get; set; }
        [Required]
        public string Titel { get; set; }
        [Required]
        public int Organizer_Id { get; set; }
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




    }
}
