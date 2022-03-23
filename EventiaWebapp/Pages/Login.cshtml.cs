using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty] public string user { get; set; }

        public void OnGet()
        {
        }
    }
}
