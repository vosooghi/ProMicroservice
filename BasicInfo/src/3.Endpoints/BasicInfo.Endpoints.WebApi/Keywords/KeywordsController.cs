using BasicInfo.Core.Contracts.Keywords.Commands.ActiveKeywords;
using BasicInfo.Core.Contracts.Keywords.Commands.ChangeTitles;
using BasicInfo.Core.Contracts.Keywords.Commands.CreateKeywords;
using BasicInfo.Core.Contracts.Keywords.Commands.InactiveKeywords;
using BasicInfo.Core.Contracts.Keywords.Queries.SearchTitleAndStatus;
using Ground.Core.RequestResponse.Queries;
using Ground.Endpoints.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BasicInfo.Endpoints.WebApi.Keywords
{
    [Route("api/[controller]")]    
    public class KeywordsController : BaseController
    {
        [HttpPost("CreateKeyword")]
        public async Task<IActionResult> CreateKeyword(CreateKeyword createKeyword)
        {
            return await Create<CreateKeyword,long>(createKeyword);
        }

        [HttpPost("ChangeTitle")]
        public async Task<IActionResult> ChangeTitle(ChangeTitle changeTitle)
        {
            return await Edit(changeTitle);
        }

        [HttpPost("Active")]
        public async Task<IActionResult> Active(ActiveKeyword activeKeyword)
        {
            return await Edit(activeKeyword);
        }
        [HttpPost("Inactive")]
        public async Task<IActionResult> Inactive(InactiveKeyword inactiveKeyword)
        {
            return await Edit(inactiveKeyword);
        }

        [HttpGet("SearchTitleAndStatus")]
        public async Task<IActionResult> SearchTitleAndStatus(TitleAndStatus titleAndStatus)
        {
            return await Query<TitleAndStatus,PageData<KeywordSearchResult>>(titleAndStatus);
        }

    }
}
