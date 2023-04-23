namespace ReferralRockWebApp.Models
{
    public class Referral
    {
        public Guid id { get; set; }
        public string displayName { get; set; } = "";
        public string firstName { get; set; } = "";
        public string lastName { get; set; } = "";
        public string fullName { get; set; } = "";
        public string email { get; set; } = "";
        public string memberReferralCode { get; set; } = "";
    }
}
