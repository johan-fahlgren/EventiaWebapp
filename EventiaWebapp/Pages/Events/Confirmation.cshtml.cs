using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Events
{
    public class ConfirmationModel : PageModel
    {
        private readonly EventService _eventService;
        public Event? ThisEvent { get; set; }
        private readonly ILogger<ConfirmationModel> _logger;

        public ConfirmationModel(ILogger<ConfirmationModel> logger, EventService eventService)
        {
            _eventService = eventService;
            _logger = logger;
        }

        public void OnGet(int eventId)
        {
            ThisEvent = _eventService.GetEvents()
                .Find(e => e.EventId == eventId);
        }

        public IActionResult OnPost(int idEvent)
        {
            ThisEvent = _eventService.GetEvents()
                .Find(e => e.EventId == idEvent);

            if (ThisEvent == null)
            {
                _logger.LogError("Missing event info, try again");
                RedirectToPage("../error", new { errorMsg = "ERROR! WARNING!" });
            }

            _eventService.AddEventToAttendee(1, idEvent);

            return Page();
        }
    }
}
