using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Admin
{
    [Authorize(Roles = "administrator")]
    public class IndexModel : PageModel
    {
        private readonly DataLayer.Backend.Admin _admin;

        public IndexModel(DataLayer.Backend.Admin admin)
        {
            _admin = admin;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {

            await _admin.RecreateAndSeedTestDatabase(); //TODO - Resetting database reseeds Admin and Cookie persists. site crash :O! 
            return Page();
        }
    }
}
