using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ReferralRockWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRRHttpClient _httpClient;

        public IndexModel(ILogger<IndexModel> logger, IRRHttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public void OnGet()
        {
            _httpClient.OnGet();
        }
    }
}