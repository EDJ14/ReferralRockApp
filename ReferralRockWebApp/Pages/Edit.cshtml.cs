using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReferralRockWebApp.Data;
using ReferralRockWebApp.Models;

namespace ReferralRockWebApp.Pages
{
    public class EditModel : PageModel
    {
        public readonly IRRHttpClient _httpClient;

        public EditModel(IRRHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty(SupportsGet = true)]
        public Guid? referralId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? displayName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? firstName { get; set; }


        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            referralId = id;
            firstName = (await _httpClient.Get<ReferralsResp>("api/referrals"))?.referrals.Where(r => r.id == id).First().firstName;


            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostButton(Guid? id)
        {
            var req = new UpdateReferralReq();
            var newReferral = new Referral();
            req.query.primaryInfo.referralId = referralId;
            newReferral.firstName = firstName;
            newReferral.displayName = displayName;
            req.referral = newReferral;

            var memberId = (await _httpClient.Get<ReferralsResp>("api/referrals"))?.referrals.Where(r => r.id == referralId).First().referringMemberId;
            await _httpClient.Post<List<UpdateReferralReq>, List<UpdateReferralReq>>("api/referral/update", new List<UpdateReferralReq>() { req });

            return RedirectToPage("./Referral", new { id =  memberId });
        }
    }
}
