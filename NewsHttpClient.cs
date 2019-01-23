using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class NewsHttpClientService
{
    public HttpClient Client { get; }

    public NewsHttpClientService(HttpClient client)
    {
        client.BaseAddress = new Uri("https://api.github.com/");
        // GitHub API versioning
        client.DefaultRequestHeaders.Add("Accept", 
            "application/json");
        // GitHub requires a user-agent
        client.DefaultRequestHeaders.Add("User-Agent", 
            "HttpClientFactory-Sample");

        Client = client;
    }

    public async Task<JsonResult> GetSportsArticles()
    {
        var response = await Client.GetAsync(
            "/repos/aspnet/docs/issues?state=open&sort=created&direction=desc");

        response.EnsureSuccessStatusCode();

        var result = await response.Content
            .ReadAsAsync<JsonResult>();

        return result;
    }
}