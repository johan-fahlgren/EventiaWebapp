using DataLayer.Model;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Organizer
{
    public class OrganizeEventsModel : PageModel
    {
        private readonly OrganizerService _organizerService;
        private readonly UserManager<EventiaUser> _userManager;

        public OrganizeEventsModel(OrganizerService organizerService, UserManager<EventiaUser> usermanager)
        {
            _organizerService = organizerService;
            _userManager = usermanager;
        }

        public List<Event> EventList
        { get; set; }
        public EventiaUser? EventiaUser { get; set; }




        public async Task OnGet()
        {
            var userId = _userManager.GetUserId(User);

            EventiaUser = await _userManager.GetUserAsync(User);

            EventList =
                await _organizerService.GetOrganizerEvents(userId);

        }
    }
}
