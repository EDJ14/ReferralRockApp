namespace ReferralRockWebApp.Models
{
    public class APIResponse
    {
        public int offset { get; set; }
        public int total { get; set; }
        public string? message { get; set; }
    }
    public class MembersResp : APIResponse
    {
        public List<Member> members { get; set; } = new List<Member>();
    }

    public class ReferralsResp : APIResponse
    {
        public List<Referral> referrals { get; set; } = new List<Referral>();
    }

    public class PostReferralReq
    {
        public string? referralCode { get; set; }
        public string? firstName {get; set;}
        public string? lastName {get; set;}
    }

    public class PostReferralResp
    {
        public string? message { get; set; }
        public Referral? referral { get; set; }
    }

    public class primaryInfo
    {
        public Guid? referralId { get; set; }
    }

    public class query
    {
        public primaryInfo primaryInfo { get; set; } = new primaryInfo();
    }

    public class DeleteReferralReq
    {
        public query query { get; set; }
    }

    public class resultInfo
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }

    public class DeleteReferralResp
    {
        public query query { get; set; }
        public resultInfo resultInfo { get; set; }
    }

    public class UpdateReferralReq
    {
        public query query { get; set; } = new query();
        public Referral referral { get; set; } = new Referral();
    }

    public class createReferralResp
    {
        public string message { get; set; }
        public Referral? referral { get; set; }
    }
}
