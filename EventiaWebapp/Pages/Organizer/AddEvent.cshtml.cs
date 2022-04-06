using DataLayer.Data;
using DataLayer.Model;
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
        private readonly EventiaDbContext _dbContext;

        public AddEventModel(UserManager<EventiaUser> userManager, EventiaDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }


        [BindProperty(SupportsGet = true)]
        public InputModel Input { get; set; }

        public class InputModel
        {

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Titel")]
            public string Titel { get; set; }

            [Required]
            [DataType(DataType.MultilineText)] //TODO(done) - won't show as "<textarea>"
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

            /* //TODO - upload file and set img url
            [DataType(DataType.Upload)] 
            [Display(Name = "Event image")]
            public IFormFile EventImg { get; set; } 
            */

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

            var result = await _dbContext.AddAsync(newEvent);
            await _dbContext.SaveChangesAsync();

            return Page(); //quick fix :)
        }
    }
}
