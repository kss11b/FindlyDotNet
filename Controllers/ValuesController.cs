using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace webApiProject.Controllers
{
    [Route("/")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IHttpClientFactory _httpClientFactory;

        public ValuesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private Articles ParseArticles(string json) {
            Articles articles = JsonConvert.DeserializeObject<Articles>(json);
            return articles;
        }
        // GET api/values
        [HttpGet("tech")]
        // <IEnumerable<string>>
        public async Task<ActionResult> GetTechArticles()
        {
            var client =_httpClientFactory.CreateClient("NewsApiClient");
            var techResult = await client.GetStringAsync("https://newsapi.org/v1/articles?source=hacker-news&apiKey=f76904152bf944798a8a79a3be817402");
            
            
            return Ok(ParseArticles(techResult).Status);
        }

        [HttpGet("sports")]
        // <IEnumerable<string>>
        public async Task<ActionResult> GetSportsArticles()
        {
            var client =_httpClientFactory.CreateClient("NewsApiClient");
            var sportsResult  = await client.GetStringAsync("https://newsapi.org/v1/articles?source=espn&apiKey=f76904152bf944798a8a79a3be817402");
            
            return Ok(sportsResult);
        }

        [HttpGet("business")]
        // <IEnumerable<string>>
        public async Task<ActionResult> GetBusinessArticles()
        {
            var client =_httpClientFactory.CreateClient("NewsApiClient");
            var sportsResult  = await client.GetStringAsync("https://newsapi.org/v1/articles?source=business-insider&apiKey=f76904152bf944798a8a79a3be817402");
            
            return Ok(sportsResult);
        }

        [HttpGet("entertainment")]
        // <IEnumerable<string>>
        public async Task<ActionResult> GetEntertainmentArticles()
        {
            var client =_httpClientFactory.CreateClient("NewsApiClient");
            var entertainmentResult  = await client.GetStringAsync("https://newsapi.org/v1/articles?source=entertainment-weekly&apiKey=f76904152bf944798a8a79a3be817402");
            
            return Ok(entertainmentResult);
        }

        [HttpGet("science")]
        // <IEnumerable<string>>
        public async Task<ActionResult> GetScienceArticles()
        {
            var client =_httpClientFactory.CreateClient("NewsApiClient");
            var scienceResult  = await client.GetStringAsync("https://newsapi.org/v1/articles?source=national-geographic&apiKey=f76904152bf944798a8a79a3be817402");
            
            return Ok(scienceResult);
        }

    }
}
