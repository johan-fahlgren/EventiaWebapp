using DataLayer.Model;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages
{
    [Authorize(Roles = "user")]
    public class MyEventsModel : PageModel
    {
        private readonly EventService _eventService;
        private readonly UserManager<EventiaUser> _userManager;
        public List<Event> UserEvents
        { get; set; }
        public EventiaUser? EventiaUser { get; set; }


        public MyEventsModel(EventService eventService, UserManager<EventiaUser> userManager)
        {
            _eventService = eventService;
            _userManager = userManager;
        }

        public async Task OnGet()
        {
            var userId = _userManager.GetUserId(User);

            UserEvents = await _eventService.UserEventsList(userId);
            EventiaUser = await _eventService.GetUser(userId);
        }
    }
}
