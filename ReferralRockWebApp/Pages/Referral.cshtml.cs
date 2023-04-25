using Microsoft.AspNetCore.Mvc.RazorPages;
using ReferralRockWebApp.Models;

namespace ReferralRockWebApp.Pages.Members
{
    public class ReferralModel : PageModel
    {
        private readonly IRRHttpClient _httpClient;
        public Guid? memberId { get; set; }
        public string memberReferralCode { get; set; } = "";
        public List<Referral> Referrals { get; set; } = new List<Referral>();
        public string memberName { get; set; } = "";

        public ReferralModel(IRRHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task OnGet(Guid? id)
        {
            memberId = id;
            Referrals = (await _httpClient.Get<ReferralsResp>("api/referrals"))?.referrals.Where(r => r.referringMemberId == memberId).ToList();
            memberReferralCode = Referrals.FirstOrDefault()?.memberReferralCode;
            var referringMember = (await _httpClient.Get<MembersResp>("api/members"))?.members.First(x => x.id == id);
            memberName = referringMember.firstName + " " + referringMember.lastName;
        }
    }
}
