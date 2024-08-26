using CkmBvIntegration.Domain.Models.Authentication;
using CkmBvIntegration.Domain.Models.Proposal;
using CkmBvIntegration.Infraestructure.BvNet.Interfaces.Authentication;
using CkmBvIntegration.Infraestructure.BvNet.Interfaces.Proposal;
using CkmBvIntegration.Infraestructure.BvNet.Repositories._Base;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CkmBvIntegration.Infraestructure.BvNet.Repositories.ProposalRepository
{
    public class ProposalRepository(
        IHttpClientFactory httpClientFactory,
        ILogger<ProposalRepository> logger) : BaseRepository<ProposalResponse>(httpClientFactory, "BvProposalAPI", logger), IProposalRepository
    {
        private ILogger _logger = logger;

        public async Task<ProposalResponse> RequestCreditCardProposal(ProposalRequest proposalRequest, string token)
        {
            string relativeURL = $"";
            string jsonResponse;

            try
            {
                jsonResponse = await PostAsync(relativeURL, proposalRequest, token,"JSON");
            }
            catch (Exception ex)
            {
                _logger.LogError(message: "Error when execute RequestCreditCardProposal: " + ex.Message);
                throw;
            }

            ProposalResponse proposalResponse = JsonConvert.DeserializeObject<ProposalResponse>(jsonResponse) ?? new ProposalResponse();
            return proposalResponse;
        }
    }
}
