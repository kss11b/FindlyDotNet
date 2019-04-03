using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
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

        private IEnumerable<Article> ParseArticles(string json, string searchTerm) {
            // Regex rgx = new Regex();
            Articles articles = JsonConvert.DeserializeObject<Articles>(json);
             var result = articles.ArticlesList.Where(x => 
                    x.Title.Contains(searchTerm.ToLower())
             );
            return result;
        }
        // GET api/values
        [HttpGet("tech/{searchTerm}")]
        // <IEnumerable<string>>
        public async Task<ActionResult> GetTechArticles(string searchTerm)
        {
            var client =_httpClientFactory.CreateClient("NewsApiClient");
            var techResult = await client.GetStringAsync("https://newsapi.org/v1/articles?source=hacker-news&apiKey=f76904152bf944798a8a79a3be817402");
            
            
            return Ok(ParseArticles(techResult, searchTerm));
        }

        [HttpGet("sports/{searchTerm}")]
        // <IEnumerable<string>>
        public async Task<ActionResult> GetSportsArticles(string searchTerm)
        {
            var client =_httpClientFactory.CreateClient("NewsApiClient");
            var sportsResult  = await client.GetStringAsync("https://newsapi.org/v1/articles?source=espn&apiKey=f76904152bf944798a8a79a3be817402");
            
            return Ok(ParseArticles(sportsResult, searchTerm));
        }

        [HttpGet("business/{searchTerm}")]
        // <IEnumerable<string>>
        public async Task<ActionResult> GetBusinessArticles(string searchTerm)
        {
            var client =_httpClientFactory.CreateClient("NewsApiClient");
            var sportsResult  = await client.GetStringAsync("https://newsapi.org/v1/articles?source=business-insider&apiKey=f76904152bf944798a8a79a3be817402");
            
            return Ok(ParseArticles(sportsResult, searchTerm));
        }

        [HttpGet("entertainment/{searchTerm}")]
        // <IEnumerable<string>>
        public async Task<ActionResult> GetEntertainmentArticles(string searchTerm)
        {
            var client =_httpClientFactory.CreateClient("NewsApiClient");
            var entertainmentResult  = await client.GetStringAsync("https://newsapi.org/v1/articles?source=entertainment-weekly&apiKey=f76904152bf944798a8a79a3be817402");
            
            return Ok(ParseArticles(entertainmentResult, searchTerm));
        }

        [HttpGet("science/{searchTerm}")]
        // <IEnumerable<string>>
        public async Task<ActionResult> GetScienceArticles(string searchTerm)
        {
            var client =_httpClientFactory.CreateClient("NewsApiClient");
            var scienceResult  = await client.GetStringAsync("https://newsapi.org/v1/articles?source=national-geographic&apiKey=f76904152bf944798a8a79a3be817402");
            
            return Ok(ParseArticles(scienceResult, searchTerm));
        }

    }
}
