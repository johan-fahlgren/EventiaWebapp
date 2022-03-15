
using Microsoft.AspNetCore.Mvc;

namespace EventiaWebapp.Controllers
{
    public class Events : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpComingEvents()
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
