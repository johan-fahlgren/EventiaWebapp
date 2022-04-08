using DataLayer.Model;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EventiaWebapp.Pages.Organizer
{
    [Authorize(Roles = "organizer")]
    public class AddEventModel : PageModel
    {

        private readonly UserManager<EventiaUser> _userManager;
        private readonly OrganizerService _organizerService;

        public AddEventModel(UserManager<EventiaUser> userManager, OrganizerService organizerService)
        {
            _userManager = userManager;
            _organizerService = organizerService;
        }


        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Titel")]
            public string Titel { get; set; }

            [Required]
            [DataType(DataType.MultilineText)]
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

            ///TODO - upload file and set img url
            [DataType(DataType.Upload)]
            [Display(Name = "Event image")]
            public IFormFile? EventImg { get; set; }

        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid) return Page();

            var user = await _userManager.GetUserAsync(User);

            var newEvent = new Event
            {
                Titel = Input.Titel,
                organizer = user,
                Description = Input.Description,
                Place = Input.Place,
                Address = Input.Address,
                Date = Input.Date,
                Spots_Available = Input.SpotsAvailable,
                EventImg = ""
            };

            await _organizerService.AddEvent(newEvent);

            return Page(); //quick fix :)
        }
    }
}
