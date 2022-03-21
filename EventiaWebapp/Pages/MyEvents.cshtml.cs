using EventiaWebapp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages
{
    public class MyEventsModel : PageModel
    {
        private readonly EventService _eventService;

        public MyEventsModel(EventService eventService)
        {
            _eventService = eventService;
        }

        public void OnGet()
        {
        }
    }
}
