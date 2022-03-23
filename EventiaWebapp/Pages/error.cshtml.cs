using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages
{
    public class errorModel : PageModel
    {
        private readonly ILogger<errorModel> _logger;

        public string ErrorMessage;

        public errorModel(ILogger<errorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string errorMsg)
        {
            ErrorMessage = errorMsg;
        }
    }
}
