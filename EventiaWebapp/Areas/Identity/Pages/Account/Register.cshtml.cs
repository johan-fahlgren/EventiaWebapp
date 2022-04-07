﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using DataLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventiaWebapp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<EventiaUser> _signInManager;
        private readonly UserManager<EventiaUser> _userManager;
        private readonly IUserStore<EventiaUser> _userStore;
        private readonly ILogger<RegisterModel> _logger;


        public RegisterModel(
            UserManager<EventiaUser> userManager,
            IUserStore<EventiaUser> userStore,
            SignInManager<EventiaUser> signInManager,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            _logger = logger;

        }


        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public EventiaUser NewUser { get; set; }

        public class InputModel
        {

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Username")]
            public string UserName { get; set; }

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

            [DataType("bool")]
            [Display(Name = "Organizer?")]
            public bool OrganizerCheckbox { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

        }

        public async Task<IActionResult> OnPostAsync(string returnUrl)
        {
            returnUrl ??= Url.Content("~/");


            if (ModelState.IsValid)
            {
                //var user = new EventiaUser();

                if (Input.OrganizerCheckbox is false)
                {
                    NewUser = new EventiaUser()
                    {
                        UserName = Input.UserName,
                        Email = Input.Email,
                        Application = null
                    };
                }
                else
                {
                    NewUser = new EventiaUser()
                    {
                        UserName = Input.UserName,
                        Email = Input.Email,
                        Application = new RoleApplication()
                    };
                }




                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _userManager.AddToRoleAsync(user, "user");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private EventiaUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<EventiaUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(EventiaUser)}'. " +
                    $"Ensure that '{nameof(EventiaUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

    }
}
