using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReferralRockWebApp.Models;

namespace ReferralRockWebApp.Pages.Members
{
    public class ReferralModel : PageModel
    {
        private readonly IRRHttpClient _httpClient;
        public Guid? memberId { get; set; }
        public string memberReferralCode { get; set; } = "";
        public List<Referral> Referrals { get; set; } = new List<Referral>();
        public bool showAddnew { get; set; } = true;

        public ReferralModel(IRRHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task OnGet(Guid? id)
        {
            memberId = id;
            Referrals = (await _httpClient.Get<ReferralsResp>("api/referrals"))?.referrals.ToList();
            memberReferralCode = Referrals.FirstOrDefault().memberReferralCode;
        }
        
        public void onAddNew()
        {
            showAddnew = true;
        }
        //[BindProperty]
        //public Member Member { get; set; } = default!;
        
        //public async Task OnAddReferral(PostReferralReq req)
        //{
        //    await _httpClient.Post<PostReferralResp, PostReferralReq>("api/referrals", req);
        //}

        //public async Task<IActionResult> OnPostAsync()
        //{
        //  if (!ModelState.IsValid || Member == null)
        //    {
        //        return Page();
        //    }

        //    return RedirectToPage("./Index");
        //}
    }
}
