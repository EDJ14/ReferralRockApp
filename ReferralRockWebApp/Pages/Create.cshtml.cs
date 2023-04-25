using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReferralRockWebApp.Data;
using ReferralRockWebApp.Models;

namespace ReferralRockWebApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IRRHttpClient _httpClient;
        [BindProperty(SupportsGet = true)]
        public string referralCode { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? lastName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? firstName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? email { get; set; }
        public CreateModel(IRRHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task OnGet(Guid? id)
        {
            referralCode = (await _httpClient.Get<MembersResp>("api/members"))?.members.Where(r => r.id == id).First().referralCode;
        }

        [BindProperty]
        public Member Member { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostButton(Guid? id)
        {
            var newReferralReq = new newReferral();
            newReferralReq.referralCode = referralCode;
            newReferralReq.firstName = firstName;
            newReferralReq.lastName = lastName;
            newReferralReq.email = email;

            var memberId = (await _httpClient.Get<ReferralsResp>("api/referrals"))?.referrals.Where(r => r.memberReferralCode == referralCode).First().referringMemberId;
            await _httpClient.Post<createReferralResp, newReferral>("api/referrals", newReferralReq);

            return RedirectToPage("./Referral", new { id = memberId });
        }
    }
}
