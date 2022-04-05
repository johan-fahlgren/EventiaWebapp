using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EventiaWebapp.Pages.Organizer
{
    public class AddEventModel : PageModel
    {

        public InputModel Input;

        public class InputModel
        {

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Titel")]
            public string Titel { get; set; }

            [Required]
            [DataType(DataType.MultilineText)] //TODO - won't show as "<textarea>"
            [Display(Name = "Description")]
            public string Description { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Place/arena")]
            public string Place { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Address")]
            public string Address { get; set; }

            [Required]
            [DataType(DataType.DateTime)]
            [Display(Name = "Date")]
            public DateTime Date { get; set; }

            [Required]
            [DataType("Int")]
            [Display(Name = "Spots Available")]
            public int SpotsAvailable { get; set; }

            [DataType(DataType.Upload)]
            [Display(Name = "Event image")]
            public string EventImg { get; set; } //TODO - upload file and set img url

        }

        public void OnGet()
        {
        }
    }
}
