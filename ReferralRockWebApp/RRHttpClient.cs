using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;
using ReferralRockWebApp.Models;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;

public class RRHttpClient : IRRHttpClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private const string BaseURL = "https://api.referralrock.com/api/members";

    public RRHttpClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task OnGet()
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.referralrock.com/api/members")
        {
            Headers =
            {
                //{ HeaderNames.Accept, "application/vnd.github.v3+json" },
                //{ HeaderNames.UserAgent, "HttpRequestsSample" },
                { HeaderNames.Authorization, "Basic ZGE3MTc1NTQtMzk1ZC00YmJmLWFlZTMtZmRmMDcwYWJjYmE1OmY0OTM0YzQ2LTdhY2EtNGNkZi1hOThhLTQ0YjRhYjVjNTg4Nw==" }
            }
        };

        var httpClient = _httpClientFactory.CreateClient();
        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        try
        {
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                var Members = await JsonSerializer.DeserializeAsync
                    <IEnumerable<Member>>(contentStream);

                var g = 'd';
            }
        } catch (Exception ex)
        {
            var d = 'd';
        }
    }
}