using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReferralRockWebApp.Data;
using ReferralRockWebApp.Models;

namespace ReferralRockWebApp.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly IRRHttpClient _httpClient;
        public string referralId { get; set; }

        public DeleteModel(IRRHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deleteRequest = new DeleteReferralReq
            {
                query = new query
                {
                    primaryInfo = new primaryInfo
                    {
                        referralId = referralId
                    }
                }
            };

            var resp = await _httpClient.Delete<DeleteReferralResp, List<DeleteReferralReq>>("api/referral/remove", new List<DeleteReferralReq>() { deleteRequest });

            return Page();
        }
    }
}
