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
    private readonly IConfiguration Configuration;
    private const string BaseURL = "https://api.referralrock.com/";

    public RRHttpClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        Configuration = configuration;
    }

    private string GetFormattedApiKey()
    {
        var config = new Config();
        Configuration?.GetSection(Config.APIKeys).Bind(config);

        return "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes($"{config.RRPublicKey}:{config.RRPrivateKey}"));
    }

    public async Task<T?> Get<T>(string endpoint)
    {
        var config = new Config();
        Configuration.GetSection(Config.APIKeys).Bind(config);

        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, BaseURL + endpoint)
        {
            Headers =
            {
                { HeaderNames.Authorization, GetFormattedApiKey() }
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