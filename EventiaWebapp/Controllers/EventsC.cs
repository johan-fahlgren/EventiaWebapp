
using Microsoft.AspNetCore.Mvc;

namespace EventiaWebapp.Controllers
{
    public class EventsC : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Booked()
        {
            return View();
        }

        public IActionResult Join(Guid id)
        {
            return View(id);
        }

        public IActionResult Confirmation(Guid id)
        {
            return View(id);
        }
    }
}
