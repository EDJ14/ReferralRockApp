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
    private const string BaseURL = "https://api.referralrock.com/";

    public RRHttpClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<T?> Get<T>(string endpoint)
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, BaseURL + endpoint)
        {
            Headers =
            {
                //{ HeaderNames.Accept, "application/vnd.github.v3+json" },
                //{ HeaderNames.UserAgent, "HttpRequestsSample" },
                { HeaderNames.Authorization, "" }
            }
        };

        var httpClient = _httpClientFactory.CreateClient();
        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);


        using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
        {
            var resp = await JsonSerializer.DeserializeAsync
                <T>(contentStream);

            return resp;
        }

    }
}