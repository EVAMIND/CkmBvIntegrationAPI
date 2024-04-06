using CkmBvIntegration.API.Controllers.Base;
using CkmBvIntegration.API.Extensions;
using CkmBvIntegration.Application.Interfaces.PDECOffer;
using CkmBvIntegration.Application.TransferObjects.Proposal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CkmBvIntegration.API.Controllers.PDECOffer
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDECOfferController : BaseController
    {
        private ILogger _logger;
        private readonly IPDECOfferApplication _iPDECOfferApplication;
        public PDECOfferController(ILogger<PDECOfferController> logger, IPDECOfferApplication pDECOfferApplication): base(logger)
        {
            _iPDECOfferApplication = pDECOfferApplication;
            _logger = logger;
        }

        [HttpPost("RequestCreditOfferAsync")]
        public async Task<ActionResult<PDECOfferResponseDTO>> RequestCreditOfferAsync([FromBody] PDECOfferRequestDTO requestDTO)
        {
            string token = HttpContext.GetBearerToken();

            if (String.IsNullOrEmpty(token))
                return Unauthorized();

            return await ExecuteAsync(async () =>
            {
                _logger.LogInformation("Iniciando processo de solicitação de oferta de crédito");

                PDECOfferResponseDTO responseDTO = await _iPDECOfferApplication.RequestCreditOfferAsync(requestDTO, token);

                return responseDTO == null ? throw new Exception("") : responseDTO;
            });
        }
    }
}
