using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebAPIClient.Models;
using Microsoft.FeatureManagement;

namespace WebAPIClient.Controllers {
    [ApiController]
    [Route("repositories")]
    public class RepositoryController : ControllerBase {
        private IFeatureManager _featureManager;
        public RepositoryController(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        private static readonly HttpClient client = new HttpClient();

        [HttpGet]
        [Route("{company}")]
        public async Task<List<Repository>> ProcessRepositoriesWithCache(string company, [FromServices] IMemoryCache _cache)
        {
            if (await _featureManager.IsEnabledAsync("CacheFeatureFlag"))
            {
                var cacheEntry = await _cache.GetOrCreateAsync(company, async entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
                    entry.SetPriority(CacheItemPriority.High);
                    
                    return await ListRepositoriesByName(company);
                });
                return cacheEntry;
            }
            else return await ListRepositoriesByName(company);            
        }

        /*[HttpGet]
        [Route("{company}")]
        public async Task<List<Repository>> ProcessRepositories(string company)
        {
            return await ListRepositoriesByName(company);
        }*/

        private async Task<List<Repository>> ListRepositoriesByName(string companyName)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync($"https://api.github.com/orgs/{companyName}/repos");
            var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
            return repositories;
        }

    }
}