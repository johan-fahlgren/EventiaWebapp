using DataLayer.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

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


        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {

            [Required]
            [Display(Name = "User name")]
            public string User { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }



        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }



        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var newUser = new EventiaUser { UserName = $"{Input.User}", Email = $"{Input.Email}" };

                var result =
                    await _userManager.CreateAsync(newUser, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("New EventiaUser created");
                    await _userManager.AddToRoleAsync(newUser, "user");



                }

            }

            return Page();
        }
    }
}
