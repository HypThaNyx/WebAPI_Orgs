using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIClient.Models;

namespace WebAPIClient.Controllers {
    [ApiController]
    [Route("v1/repositories")]
    public class RepositoryController : ControllerBase {
        private static readonly HttpClient client = new HttpClient();

        [HttpGet]
        [Route("{company:string}")]
        private async Task<List<Repository>> ProcessRepositories(string company)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var task = client.GetStreamAsync($"https://api.github.com/orgs/{company}/repos");
            var result = await JsonSerializer.DeserializeAsync<List<Repository>>(await task);

            return result;
        }

    }
}