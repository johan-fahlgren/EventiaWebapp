using DataLayer.Model;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages
{
    public class EventsModel : PageModel
    {
        private readonly EventService _eventService;
        public List<Event?> EventList;

        public EventsModel(EventService eventService)
        {
            _eventService = eventService;
        }

        public async Task OnGet()
        {
            EventList = await _eventService.GetEvents();

        }

        public IActionResult OnPost(int idEvent)
        {
            return RedirectToPage("/events/Confirmation", new { eventId = idEvent });
        }
    }
}
