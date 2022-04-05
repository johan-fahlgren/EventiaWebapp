using DataLayer.Model;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Events
{
    public class ConfirmationModel : PageModel
    {
        private readonly EventService _eventService;
        private readonly UserManager<EventiaUser> _userManager;

        public Event? ThisEvent { get; set; }
        public EventiaUser EventiaUser { get; set; }
        private readonly ILogger<ConfirmationModel> _logger;


        public ConfirmationModel(
            ILogger<ConfirmationModel> logger,
            EventService eventService,
            UserManager<EventiaUser> userManager)
        {
            _eventService = eventService;
            _logger = logger;
            _userManager = userManager;
        }

        public async void OnGet(int eventId)
        {
            var userId = _userManager.GetUserId(User);

            EventiaUser = await _eventService.GetUser(userId);

            ThisEvent = await _eventService.GetThisEvent(eventId);
        }

        public async Task<IActionResult> OnPost(int idEvent)
        {
            var userId = _userManager.GetUserId(User);

            EventiaUser = await _eventService.GetUser(userId);

            ThisEvent = await _eventService.GetThisEvent(idEvent);


            if (ThisEvent == null)
            {
                _logger.LogError("Missing event info, try again");
                return RedirectToPage("../error", new { errorMsg = "Missing event info, please try again" });
            }


            _eventService.AddEventToAttendee(userId, idEvent);
            return Page();

        }
    }
}
