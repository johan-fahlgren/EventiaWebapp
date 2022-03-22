using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Events
{
    public class ConfirmationModel : PageModel
    {
        private readonly EventService _eventService;
        public Event? ThisEvent { get; set; }

        public ConfirmationModel(EventService eventService)
        {
            _eventService = eventService;
        }

        public void OnGet(int eventId)
        {
            ThisEvent = _eventService.GetEvents()
                .Find(e => e.EventId == eventId);
        }

        public void OnPost(int idEvent)
        {
            _eventService.AddEventToAttendee(1, idEvent);
        }
    }
}
