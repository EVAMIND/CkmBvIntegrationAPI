using CkmBvIntegration.Domain.Models.Authentication;
using CkmBvIntegration.Domain.Models.PDECOffer;
using CkmBvIntegration.Domain.Models.Proposal;
using CkmBvIntegration.Infraestructure.BvNet.Interfaces.Authentication;
using CkmBvIntegration.Infraestructure.BvNet.Interfaces.Proposal;
using CkmBvIntegration.Infraestructure.BvNet.Repositories._Base;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CkmBvIntegration.Infraestructure.BvNet.Repositories.ProposalRepository
{
    public class PDECOfferRepository(
        IHttpClientFactory httpClientFactory,
        ILogger<PDECOfferRepository> logger) : BaseRepository<PDECOfferResponse>(httpClientFactory, "BvPDECOfferAPI", logger), IPDECOfferRepository
    {
        private ILogger _logger = logger;

        public async Task<PDECOfferResponse> RequestCreditOfferAsync(PDECOfferRequest pDECOfferRequest, string token)
        {

            string relativeURL = $"{pDECOfferRequest.dados.codigoParceiro}";
            string jsonResponse;

            try
            {
                jsonResponse = await PostAsync(relativeURL, pDECOfferRequest, token);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: "Error when execute RequestCreditOfferAsync: " + ex.Message);
                throw;
            }

            PDECOfferResponse pDECOfferResponse = JsonConvert.DeserializeObject<PDECOfferResponse>(jsonResponse) ?? new PDECOfferResponse();
            return pDECOfferResponse;
        }
    }
}
