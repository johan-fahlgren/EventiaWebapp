using DataLayer.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages
{
    public class RegisterModel : PageModel
    {

        private readonly SignInManager<EventiaUser> _signInManger;
        private readonly UserManager<EventiaUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(SignInManager<EventiaUser> signInManger,
            UserManager<EventiaUser> userManager,
            ILogger<RegisterModel> logger)
        {
            _signInManger = signInManger;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
        }

        public async Task OnPostAsync()
        {
            if (ModelState.IsValid)
            {



            }
        }
    }
}
