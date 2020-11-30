using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPIClient.Models;

namespace WebAPIClient.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly HttpClient _client;

        public RepositoryService(HttpClient client)
        {
            _client = client;
            HttpStart(_client);
        }

        private void HttpStart(HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
        }    

        public async Task<List<Repository>> ListRepositoriesByCompanyName(string organizationName)
        {
            HttpStart(_client);
            var login = $"https://api.github.com/orgs/{organizationName}/repos";
            var streamTask = _client.GetStreamAsync(login);
            try
            {
                return await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }

    public interface IRepositoryService
    {
        Task<List<Repository>> ListRepositoriesByCompanyName(string organizationName);
    }
}