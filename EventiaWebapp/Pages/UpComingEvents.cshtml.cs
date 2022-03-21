using EventiaWebapp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages
{
    public class EventsModel : PageModel
    {
        private readonly EventService _eventService;

        public EventsModel(EventService eventService)
        {
            _eventService = eventService;
        }

        public void OnGet()
        {
        }
    }
}
