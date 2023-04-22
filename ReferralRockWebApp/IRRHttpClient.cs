using ReferralRockWebApp.Models;

public interface IRRHttpClient
{
    IEnumerable<Member>? Members { get; set; }

    Task OnGet();
}