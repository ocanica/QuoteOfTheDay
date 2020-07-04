using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QotD.Api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace QotD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QotD : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiKey;

        public QotD(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _apiKey = configuration["QuoteService:ServiceApiKey"];
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://api.paperquotes.com/apiv1/qod/");
            request.Headers.Add("Authorization", $"Token {_apiKey}");

            var client = _httpClientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<Result>(responseStream);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
            
        }


    }
}
