using Microsoft.Identity.Web;
using System.Net.Http.Headers;

namespace KeuzeWijzerMvc.Services
{
    public class ApiClientFactory
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _factory;
        private readonly ITokenAcquisition _tokenAcquisition;
        private readonly Uri _baseaddress;
        private readonly string[] _defaultScopes;

        public ApiClientFactory(IHttpClientFactory factory, ITokenAcquisition tokenAcquisition, IConfiguration configuration)
        {
            _configuration = configuration;
            _factory = factory;
            _tokenAcquisition = tokenAcquisition;
            _baseaddress = new Uri(_configuration.GetValue<string>("ApiUri"));
            _defaultScopes = _configuration.GetSection("AzureAd:DefaultApiScopes").Get<string[]>();
        }

        public async Task<HttpResponseMessage> Get(string path, string key)
        {
            if (key != "") path += "/" + key;
            var client = await CreateClient();
            var response = await client.GetAsync(path);
            return response;
        }

        public async Task<HttpResponseMessage> Post<T>(string path, T entity)
        {
            var client = await CreateClient();
            var response = await client.PostAsJsonAsync(path, entity);
            return response;
        }

        public async Task<HttpResponseMessage> Put<T>(string path, string key, T entity)
        {
            path += "/" + key;
            var client = await CreateClient();
            var response = await client.PutAsJsonAsync(path, entity);
            return response;
        }

        public async Task<HttpResponseMessage> Delete(string path, string key)
        {
            path += "/" + key;
            var client = await CreateClient();
            var response = await client.DeleteAsync(path);
            return response;
        }

        private async Task<HttpClient> CreateClient()
        {
            var client = _factory.CreateClient();
            client.BaseAddress = _baseaddress;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _tokenAcquisition.GetAccessTokenForUserAsync(_defaultScopes));

            return client;
        }
    }
}
