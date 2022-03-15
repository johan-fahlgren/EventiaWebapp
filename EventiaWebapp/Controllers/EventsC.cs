
using Microsoft.AspNetCore.Mvc;

namespace EventiaWebapp.Controllers
{
    public class EventsC : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Events()
        {
            return View();
        }

        public IActionResult MyEvents()
        {
            return View();
        }

        public IActionResult JoinEvent(int id)
        {
            return View(id);
        }

        public IActionResult LogIn()
        {
            return View();
        }
    }
}
