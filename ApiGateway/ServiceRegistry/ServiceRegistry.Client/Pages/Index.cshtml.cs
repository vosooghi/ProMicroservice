using Microsoft.AspNetCore.Mvc.RazorPages;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;

namespace ServiceRegistry.Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string FirstName { get; set; }
        private readonly HttpClient _fName;
        DiscoveryHttpClientHandler _handler;
        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory, IDiscoveryClient client)
        {
            _logger = logger;
            _fName = httpClientFactory.CreateClient("FName");
            _handler = new DiscoveryHttpClientHandler(client);
        }

        public async Task OnGet()
        {
            var client = new HttpClient(_handler, false);            
            FirstName = await client.GetStringAsync("http://ServiceRegistry.Src/api/FName");
        }
    }
}
