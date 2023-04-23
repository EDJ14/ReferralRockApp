namespace ReferralRockWebApp.Models
{
    public class MembersResp
    {
        public int offset { get; set; }
        public int total { get; set; }
        public string? message { get; set; }
        public List<Member> members { get; set; } = new List<Member>();
    }
}
