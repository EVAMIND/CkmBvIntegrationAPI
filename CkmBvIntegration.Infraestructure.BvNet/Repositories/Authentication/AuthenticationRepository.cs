using CkmBvIntegration.Domain.Models.Authentication;
using CkmBvIntegration.Infraestructure.BvNet.Interfaces.Authentication;
using CkmBvIntegration.Infraestructure.BvNet.Repositories._Base;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CkmBvIntegration.Infraestructure.BvNet.Repositories.Authentication
{
    public class AuthenticationRepository(
        IHttpClientFactory httpClientFactory,
        ILogger<AuthenticationRepository> logger) : BaseRepository<AuthenticationResponse>(httpClientFactory, "BvTokenAPI", logger), IAuthenticationRepository
    {
        private ILogger _logger = logger;

        public async Task<AuthenticationResponse> GenerateTokenAsync(AuthenticationRequest authenticationRequest)
        {
            string relativeURL = $"";
            string jsonResponse;
            try
            {
                jsonResponse = await PostAsync(relativeURL, authenticationRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: "Error when execute GenerateTokenAsync: " + ex.Message);
                throw;
            }

   
            AuthenticationResponse token = JsonConvert.DeserializeObject<AuthenticationResponse>(jsonResponse) ?? new AuthenticationResponse();
            return token;
        }
    }
}
