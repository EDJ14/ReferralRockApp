using System.ComponentModel.DataAnnotations;

namespace ReferralRockWebApp.Models
{
    public class Referral
    {
        [Display(Name = "Referral ID")]
        public Guid id { get; set; }
        public string displayName { get; set; } = "";
        [Display(Name = "First Name")]
        public string firstName { get; set; } = "";
        [Display(Name = "Last Name")]
        public string lastName { get; set; } = "";
        public string fullName { get; set; } = "";
        [Display(Name = "Email")]
        public string email { get; set; } = "";
        public string memberReferralCode { get; set; } = "";
        public Guid? referringMemberId { get; set; }
    }

    public class newReferral : Referral
    {
        public string referralCode { get; set; }
    }
}
