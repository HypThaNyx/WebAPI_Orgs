using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.FeatureManagement;
using Microsoft.Extensions.Configuration;
using WebAPIClient.Models;
using WebAPIClient.Services;

namespace WebAPIClient.Controllers {
    [ApiController]
    [Route("repositories")]
    public class RepositoryController : ControllerBase {
        private IFeatureManager _featureManager;
        private IRepositoryService _service;

        public RepositoryController(
            IFeatureManager featureManager,
            IRepositoryService service)
        {
            _featureManager = featureManager;
            _service = service;
        }

        private static readonly HttpClient client = new HttpClient();

        [HttpGet]
        [Route("{company}")]
        public async Task<List<Repository>> ProcessRepositoriesWithCache(
            string company,
            [FromServices] IMemoryCache _cache,
            [FromServices] IConfiguration _config)
        {
            float cacheExpirationTime = 
                float.Parse(_config.GetSection("MySettings")
                .GetSection("CacheExpirationTimeInSeconds").Value);

            if (await _featureManager.IsEnabledAsync("CacheFeatureFlag"))
            {
                var cacheEntry = await _cache.GetOrCreateAsync(company, async entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheExpirationTime);
                    entry.SetPriority(CacheItemPriority.High);
                    
                    return await _service.ListRepositoriesByCompanyName(company);
                });
                return cacheEntry;
                
            } else return await _service.ListRepositoriesByCompanyName(company);                 
        }
    }
}