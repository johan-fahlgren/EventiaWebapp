using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages
{
    public class errorModel : PageModel
    {
        public string ErrorMessage;

        public void OnGet(string errorMsg)
        {
            ErrorMessage = errorMsg;
        }
    }
}
