using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages
{
    public class MyEventsModel : PageModel
    {
        private readonly EventService _eventService;
        public List<Event> UserOneEvents { get; set; }


        public MyEventsModel(EventService eventService)
        {
            _eventService = eventService;
        }

        public void OnGet()
        {
            UserOneEvents = _eventService.UserEventsList(1);
        }
    }
}
