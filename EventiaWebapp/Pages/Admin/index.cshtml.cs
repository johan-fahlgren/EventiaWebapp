using DataLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Admin
{
    [Authorize(Roles = "administrator")]
    public class IndexModel : PageModel
    {
        private readonly DataLayer.Backend.Admin _admin;
        private readonly SignInManager<EventiaUser> _signInManager;

        public IndexModel(DataLayer.Backend.Admin admin, SignInManager<EventiaUser> signInManager)
        {
            _admin = admin;
            _signInManager = signInManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await _signInManager.SignOutAsync();
            await _admin.RecreateAndSeedTestDatabase();
            return RedirectToPage("/index");
        }
    }
}
