using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

[JsonObject]

public class Articles
{
    [JsonProperty("articles")] 
    public List<Article> ArticlesList;

    [JsonProperty("status")]
    public string Status;

    [JsonProperty("totalResults")]
    public int TotalResults;
}

[JsonObject]
public class Article
{
    [JsonProperty("source")]
    public ArticleSource Source;

    [JsonProperty("author")]
    public string Author;

    [JsonProperty("title")]
    public string Title;

    [JsonProperty("description")]
    public string Description;

    [JsonProperty("url")]
    public string Url;

    [JsonProperty("publishedAt")]
    public string PublishedAt;

    [JsonProperty("content")]
    public string Content;    

}

public class ArticleSource {
    [JsonProperty("id")]
    public string Id;

    [JsonProperty("name")]
    public string Name;   
}
