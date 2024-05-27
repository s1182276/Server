using KeuzeWijzerMvc.Services.Interfaces;

namespace KeuzeWijzerMvc.Services
{
    public class ApiService<T> : IService<T> where T : new()
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _factory;
        public ApiService(IConfiguration configuration, IHttpClientFactory factory)
        {
            _configuration = configuration;
            _factory = factory;
        }

        public async Task<bool> AddAsync(T item, string path)
        {
            try
            {
                var apiClient = new ApiClientFactory(_factory, _configuration);
                var response = await apiClient.Post<T>(path, item);
                if (response.IsSuccessStatusCode) return true;
            }
            catch(Exception ex){}
            return false;
        }

        public async Task<bool> DeleteAsync(int id, string path)
        {
            var apiClient = new ApiClientFactory(_factory, _configuration);
            var response = await apiClient.Delete(path, id.ToString());
            if (response.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<List<T>> GetAsync(string path)
        {
            var items = new List<T>();
            var apiClient = new ApiClientFactory(_factory, _configuration);
            var response = await apiClient.Get(path, "");
            if (response.IsSuccessStatusCode) items = await response.Content.ReadAsAsync<List<T>>(); // Microsoft.AspNet.WebApi.Client needed
            return items;
        }

        public async Task<T> GetAsync(int id, string path)
        {
            var item = new T();
            var apiClient = new ApiClientFactory(_factory, _configuration);
            var response = await apiClient.Get(path, id.ToString());
            if (response.IsSuccessStatusCode) item = await response.Content.ReadAsAsync<T>();
            return item;
        }

        public async Task<bool> UpdateAsync(int id, T item, string path)
        {
            var apiClient = new ApiClientFactory(_factory, _configuration);
            var response = await apiClient.Put<T>(path, id.ToString(), item);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> UpdateSpecialAsync(int id, object item, string path)
        {
            var apiClient = new ApiClientFactory(_factory, _configuration);
            var response = await apiClient.Put(path, id.ToString(), item);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
