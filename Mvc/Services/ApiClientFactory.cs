namespace KeuzeWijzerMvc.Services
{
    public class ApiClientFactory
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _factory;
        private Uri _baseaddress;

        public ApiClientFactory(IHttpClientFactory factory, IConfiguration configuration)
        {
            _configuration = configuration;
            _factory = factory;
            _baseaddress = new Uri(_configuration.GetValue<string>("ApiUri"));
        }

        public async Task<HttpResponseMessage> Get(string path, string key)
        {
            if (key != "") path += "/" + key;
            var client = _factory.CreateClient();
            client.BaseAddress = _baseaddress;
            var response = await client.GetAsync(path);
            return response;
        }

        public async Task<HttpResponseMessage> Post<T>(string path, T entity)
        {
            var client = _factory.CreateClient();
            client.BaseAddress = _baseaddress;
            var response = await client.PostAsJsonAsync(path, entity);
            return response;
        }

        public async Task<HttpResponseMessage> Put<T>(string path, string key, T entity)
        {
            path += "/" + key;
            var client = _factory.CreateClient();
            client.BaseAddress = _baseaddress;
            var response = await client.PutAsJsonAsync(path, entity);
            return response;
        }

        public async Task<HttpResponseMessage> Delete(string path, string key)
        {
            path += "/" + key;
            var client = _factory.CreateClient();
            client.BaseAddress = _baseaddress;
            var response = await client.DeleteAsync(path);
            return response;
        }
    }
}
