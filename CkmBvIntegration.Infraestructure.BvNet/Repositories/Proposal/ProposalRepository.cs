using CkmBvIntegration.Domain.Models.Authentication;
using CkmBvIntegration.Infraestructure.BvNet.Interfaces.Authentication;
using CkmBvIntegration.Infraestructure.BvNet.Repositories._Base;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CkmBvIntegration.Infraestructure.BvNet.Repositories.ProposalRepository
{
    public class ProposalRepository(
        IHttpClientFactory httpClientFactory,
        ILogger<ProposalRepository> logger) : BaseRepository<AuthenticationResponse>(httpClientFactory, "BvTokenAPI", logger), IAuthenticationRepository
    {
        private ILogger _logger = logger;

        public async Task<AuthenticationResponse> GenerateTokenAsync(AuthenticationRequest authenticationRequest)
        {
            string relativeURL = $"token/id";
            string jsonResponse;
            try
            {
                jsonResponse = await GetAsync(relativeURL);
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
