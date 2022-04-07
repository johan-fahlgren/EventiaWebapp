using DataLayer.Model;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Admin
{
    [Authorize(Roles = "administrator")]
    public class ManageUsersModel : PageModel
    {

        private readonly AdminService _adminService;


        public ManageUsersModel(AdminService adminService)
        {
            _adminService = adminService;

        }

        public List<AdminService.userRoles> UserList
        { get; set; }

        public List<EventiaUser> ApplicantList
        { get; set; }


        public async Task OnGet()
        {

            UserList = await _adminService.GetUsers();
            ApplicantList = await _adminService.GetApplicants();

        }
    }
}
