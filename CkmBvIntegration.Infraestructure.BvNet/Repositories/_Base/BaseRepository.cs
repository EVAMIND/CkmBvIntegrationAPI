using CkmBvIntegration.Infraestructure.BvNet.Interfaces._Base;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
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
         
            _logger.LogInformation("Iniciando Post para a url: " + uri);

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = null;
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                _logger.LogInformation("Bearer Token adicionado.");
            }


            var requestData = BuildRequestData(content);

            var requestContent = new FormUrlEncodedContent(requestData);


            var response =  await _httpClient.PostAsync(uri, requestContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public static List<KeyValuePair<string, string>> BuildRequestData<T>(T parameters)
        {
            var requestData = new List<KeyValuePair<string, string>>();

            // Usa reflexão para iterar pelas propriedades do objeto
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                // Obtém o nome da propriedade
                string key = property.Name;

                // Obtém o valor da propriedade e converte para string
                // Usa o método ToString() para converter tipos não-string para string
                // Pode ser necessário ajustar esta parte se houver tipos complexos ou se um formato específico for necessário
                var value = property.GetValue(parameters, null)?.ToString();

                // Se o valor não for nulo, adiciona ao requestData
                if (value != null)
                {
                    requestData.Add(new KeyValuePair<string, string>(key, value));
                }
            }

            return requestData;
        }
    }


}
