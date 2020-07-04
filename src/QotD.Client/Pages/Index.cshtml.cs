using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QotD.Api.Models;
using QotD.Client.Contracts;

namespace QotD.Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IApiClient _apiClient;
        private readonly ILogger<IndexModel> _logger;
        public Result Result { get; set; }

        public IndexModel(IApiClient apiClient, ILogger<IndexModel> logger)
        {
            _apiClient = apiClient;
            _logger = logger;
        }

        public async Task OnGet()
        {
            Result = await _apiClient.Get();
        }
    }
}
