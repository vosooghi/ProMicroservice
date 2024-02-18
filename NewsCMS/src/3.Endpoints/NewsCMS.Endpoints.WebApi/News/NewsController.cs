using Ground.Core.RequestResponse.Queries;
using Ground.Endpoints.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using NewsCMS.Core.Contracts.News.Commands.CreateNews;
using NewsCMS.Core.Contracts.News.Queries.NewsDetailes;
using NewsCMS.Core.Contracts.News.Queries.NewsLists;

namespace NewsCMS.Endpoints.WebApi.News
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : BaseController
    {
        [HttpPost("CreateNews")]
        public async Task<IActionResult> Post(CreateNewsCommand createNews)
        {
            return await Create<CreateNewsCommand, long>(createNews);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> Get([FromQuery] NewsList newsList)
        {
            return await Query<NewsList, PageData<NewsListResult>>(newsList);
        }

        [HttpGet("GetDetail")]
        public async Task<IActionResult> Get([FromQuery] NewsDetaile newsDetaile)
        {
            return await Query<NewsDetaile, NewsDetaileResult>(newsDetaile);
        }
    }
}
