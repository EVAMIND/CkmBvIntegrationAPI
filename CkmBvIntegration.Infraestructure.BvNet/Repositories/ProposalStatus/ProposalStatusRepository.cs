using CkmBvIntegration.Domain.Models.Authentication;
using CkmBvIntegration.Domain.Models.Proposal;
using CkmBvIntegration.Domain.Models.ProposalStatus;
using CkmBvIntegration.Infraestructure.BvNet.Interfaces.Authentication;
using CkmBvIntegration.Infraestructure.BvNet.Interfaces.Proposal;
using CkmBvIntegration.Infraestructure.BvNet.Repositories._Base;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CkmBvIntegration.Infraestructure.BvNet.Repositories.ProposalRepository
{
    public class ProposalStatusRepository(
        IHttpClientFactory httpClientFactory,
        ILogger<ProposalStatusRepository> logger) : BaseRepository<ProposalStatusResponse>(httpClientFactory, "BvProposalStatusAPI", logger), IProposalStatusRepository
    {
        private ILogger _logger = logger;

        public async Task<ProposalStatusResponse> GetProposalStatusAsync(ProposalStatusRequest proposalStatusRequest, string token)
        {
            string relativeURL = $"?cdMeioVenda={proposalStatusRequest.cdMeioVenda}&nmParceiro={proposalStatusRequest.nmParceiro}";
            string jsonResponse;

            try
            {
                jsonResponse = await PostAsync(relativeURL, proposalStatusRequest, token);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: "Error when execute GetProposalStatusAsync: " + ex.Message);
                throw;
            }

            ProposalStatusResponse ProposalStatusResponse = JsonConvert.DeserializeObject<ProposalStatusResponse>(jsonResponse) ?? new ProposalStatusResponse();
            return ProposalStatusResponse;
        }
    }
}
