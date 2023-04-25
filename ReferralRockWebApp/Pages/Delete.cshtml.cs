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

namespace ReferralRockWebApp.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IRRHttpClient _httpClient;

        public DeleteModel(IRRHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
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
                        referralId = id
                    }
                }
            };

            var resp = await _httpClient.Delete<List<DeleteReferralResp>, List<DeleteReferralReq>>("api/referral/remove", new List<DeleteReferralReq>() { deleteRequest });

            return Page();
        }
    }
}
