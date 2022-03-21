using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages
{
    public class MyEventsModel : PageModel
    {
        private readonly EventHandler _eventHandler;

        public MyEventsModel(EventHandler eventHandler)
        {
            this._eventHandler = eventHandler;
        }


        public void OnGet()
        {

        }
    }
}
