using CkmBvIntegration.Infraestructure.BvNet.Interfaces._Base;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CkmBvIntegration.Infraestructure.BvNet.Repositories._Base
{
    public class BaseRepository<T>: IBaseRepository<T> where T : class
    {
        private readonly HttpClient _httpClient;
        private ILogger _logger;

        public BaseRepository(
            IHttpClientFactory clientFactory, 
            string clientName,
            ILogger<BaseRepository<T>> logger
            )
        {
            _httpClient = clientFactory.CreateClient(clientName);
            _logger = logger;
        }

        public async Task<string> GetAsync(string uri)
        {
            _logger.LogInformation("Iniciando request para a url : " + uri);

            //TODO: Tratar exceções dos retornos de request;
            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostAsync<T>(string uri, T content, string token = null)
        {
            //TODO: Mudar implementação para url-encoded
            _logger.LogInformation("Iniciando Post para a url: " + uri);

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = null;
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                _logger.LogInformation("Bearer Token adicionado.");
            }

            var httpContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

            var response =  await _httpClient.PostAsync(uri, httpContent);

            return await response.Content.ReadAsStringAsync();
        }

    }
}
