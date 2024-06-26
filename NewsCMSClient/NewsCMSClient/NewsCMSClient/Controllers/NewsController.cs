﻿using Microsoft.AspNetCore.Mvc;
using NewsCMSClient.Models.Keywords;
using NewsCMSClient.Models.NewsViewModels;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

namespace NewsCMSClient.Controllers
{
    public class NewsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NewsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            /*var oAuthClient = _httpClientFactory.CreateClient("oAuth");
            var discovery =await oAuthClient.GetDiscoveryDocumentAsync();
            string token="";

            if (!discovery.IsError)
            {
                var tokenResponse =await oAuthClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = discovery.TokenEndpoint,
                    ClientId = "newscmsclient",
                    ClientSecret = "newscmsclient",
                    Scope = "basicinfo newscms"
                });
                token = tokenResponse.AccessToken;
            }*/

            //Login,get token from user
            string token = await HttpContext.GetTokenAsync("access_token");
            var newsClient = _httpClientFactory.CreateClient("news");

            //newsClient.SetBearerToken(token);
            newsClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string newsListAsString = await newsClient.GetStringAsync("api/News/GetList");
            NewsListModel newsList = JsonConvert.DeserializeObject<NewsListModel>(newsListAsString);
            return View(newsList);
        }
        public async Task<IActionResult> Detail(long id)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            var newsClient = _httpClientFactory.CreateClient("news");
            newsClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string newsAsString = await newsClient.GetStringAsync($"api/News/GetDetail?NewsId={id}");
            NewsDetailViewModel newsDetail = JsonConvert.DeserializeObject<NewsDetailViewModel>(newsAsString);

            /* before implementing PollingPublisher pattern
            var biClient = _httpClientFactory.CreateClient("bi");
            string KeywordAsString = await biClient.GetStringAsync("api/Keywords/SearchTitleAndStatus");
            KeywordListResult keywordListResult = JsonConvert.DeserializeObject<KeywordListResult>(KeywordAsString);

            for (int i = 0; i < newsDetail.keywords.Count(); i++)
            {
                if (keywordListResult.queryResult.Any(c => c.businessId == newsDetail.keywords[i]))
                {
                    var keyword = keywordListResult.queryResult.Where(c => c.businessId == newsDetail.keywords[i]).FirstOrDefault();
                    newsDetail.keywords[i] = keyword.title;
                }
            }*/

            return View(newsDetail);
        }
        public async Task<IActionResult> Save()
        {
            string token = await HttpContext.GetTokenAsync("access_token");

            var biClient = _httpClientFactory.CreateClient("bi");
            biClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string keywordAsString =await biClient.GetStringAsync("api/Keywords/SearchTitleAndStatus");
            KeywordListResult keywordListResult = JsonConvert.DeserializeObject<KeywordListResult>(keywordAsString);
            ViewCreateNewsViewModel model = new ViewCreateNewsViewModel();
            foreach (var keyword in keywordListResult.queryResult)
            {
                model.Keywords.Add(keyword.businessId, keyword.title);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save([Bind(Prefix = "SaveModel")] CreateNewsViewModel model)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            var newsClient = _httpClientFactory.CreateClient("news");
            newsClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var httpContnt = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");

            var result = await newsClient.PostAsync("api/News/CreateNews", httpContnt);
            return result.IsSuccessStatusCode ? Redirect("Index") : Redirect("Save");
        }
    }
}
