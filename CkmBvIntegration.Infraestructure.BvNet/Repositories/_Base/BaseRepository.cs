using CkmBvIntegration.Infraestructure.BvNet.Interfaces._Base;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;

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

        


    }
}
