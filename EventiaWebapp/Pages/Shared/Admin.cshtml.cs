using DataLayer.Backend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Shared
{
    public class AdminModel : PageModel
    {
        private readonly Admin _admin;

        public AdminModel(Admin admin)
        {
            _admin = admin;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {

            await _admin.RecreateAndSeedTestDatabase();
            return Page();
        }
    }
}
