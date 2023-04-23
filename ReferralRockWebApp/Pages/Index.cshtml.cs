using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReferralRockWebApp.Models;

namespace ReferralRockWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRRHttpClient _httpClient;
        public List<Member>? Members { get; set; }

        public IndexModel(IRRHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task OnGet()
        {
            Members = (await _httpClient.Get<MembersResp>("api/members"))?.members.ToList();
        }
    }
}